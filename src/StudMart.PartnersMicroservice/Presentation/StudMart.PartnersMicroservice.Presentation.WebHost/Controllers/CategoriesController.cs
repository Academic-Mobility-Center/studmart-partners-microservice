using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Category;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Category;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Category;
using IResult = StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base.IResult;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Admin")]
public class CategoriesController(IMediator mediator, IMapper mapper, ILogger<CategoriesController> logger)
    : ControllerBase
{
    private async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await mediator.Send(new GetAllCategoriesRequest(), cancellationToken);
        return categories.Select(mapper.Map<CategoryResponse>);
    }

    private ObjectResult MapErrorFromLogicResult(IResult result) => result switch
    {
        CategoryNotFoundResult categoryNotFoundResult => NotFound(
            $"Category with id {categoryNotFoundResult.NotFoundId} does not exist."),
        CategoryAlreadyExistsResult categoryAlreadyExists => BadRequest(
            $"Category with name {categoryAlreadyExists.Name} already registered."),
        InternalErrorResult => BadRequest("Error while working with category")
    };
    /// <summary>
    /// Gets list of partners categories or category detailed information
    /// </summary>
    /// <param name="queryParameters">Category Id or category name or empty</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Categories list or category detailed information or 404 if category id or name was not found or 400 if error was occured</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponse>),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CategoryResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync([FromQuery] CategoryQueryParameters queryParameters,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(queryParameters));
        if (queryParameters.name is null && queryParameters.id is null)
            return Ok(await GetAllCategoriesAsync(cancellationToken));
        if (queryParameters.id is not null && queryParameters.name is not null)
            return BadRequest("It must contains only one filter");
        if (queryParameters.name is not null)
        {
            var category = await mediator.Send(new GetCategoryByNameRequest(queryParameters.name), cancellationToken);
            if (category is null)
                return NotFound(queryParameters.name);
            return Ok(mapper.Map<CategoryResponse>(category));
        }

        if (queryParameters.id is not null)
        {
            var category = await mediator.Send(new GetCategoryByIdRequest(queryParameters.id ?? 0), cancellationToken);
            if (category is null)
            {
                logger.LogWarning("Category with id  {QueryParametersId} not found", queryParameters.id);
                return NotFound(queryParameters.id);
            }

            return Ok(mapper.Map<CategoryResponse>(category));
        }

        logger.LogError("Error was created while get category");
        return BadRequest();
    }
    /// <summary>
    /// Creates new category
    /// </summary>
    /// <param name="request">Category name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>201 if category was created or 400 if category already exists</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CategoryAddRequest request,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var result = await mediator.Send(new CreateCategoryCommand(mapper.Map<CategoryAddModel>(request)),
            cancellationToken);
        if (result is ICreatedResult<CategoryModel> createdResult)
        {
            var category = createdResult.CreatedModel;
            logger.LogInformation("Category with id  {CategoryId} created", category.Id);
            await mediator.Publish(new CategoryCreatedNotification(category), cancellationToken);
            return CreatedAtAction("Get", new { id = category.Id }, mapper.Map<CategoryResponse>(category));
        }

        var error = MapErrorFromLogicResult(result);
        logger.LogWarning(error.Value!.ToString());
        return error;
    }
    /// <summary>
    /// Updates category names
    /// </summary>
    /// <param name="id">Category Id</param>
    /// <param name="request">Category new name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>204 if updated, 404 if category was not found, 400 if another category has same name or if error was ocuured</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync([FromQuery]int id, [FromBody] UpdateCategoryRequest request,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var result = await mediator.Send(new UpdateCategoryCommand(mapper.Map<UpdateCategoryModel>(request)),
            cancellationToken);
        if (result is CategoryUpdatedResult createdResult)
        {
            var category = createdResult.Model;
            logger.LogInformation("Category with id  {CategoryId} updated", category.Id);
            await mediator.Publish(new CategoryUpdatedNotification(category), cancellationToken);
            return NoContent();
        }

        var error = MapErrorFromLogicResult(result);
        logger.LogWarning(error.Value!.ToString());
        return error;
    }
    /// <summary>
    /// Deletes category
    /// </summary>
    /// <param name="id">Category Id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>204 if was deleted, 404 if category was not found or 400 if error was occured</returns>
    [HttpDelete]
    [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id, CancellationToken cancellationToken = default)
    {
        var category = await mediator.Send(new GetCategoryByIdRequest(id), cancellationToken);
        if (category is null)
        {
            logger.LogWarning("Category with id  {CategoryId} not found", id);
            return NotFound(id);
        }
        var result = await mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
        if (result is ISuccessResult)
        {
            await mediator.Publish(new CategoryDeletedNotification(category), cancellationToken);
            logger.LogInformation("Category with id {Id} was deleted", id);
            return NoContent();
        }
        logger.LogError("Error while deleting category with Id {Id}", id);
        return BadRequest();
    }
}