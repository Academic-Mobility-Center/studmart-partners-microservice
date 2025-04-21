using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Category;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Category;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Category;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriesController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await mediator.Send(new GetAllCategoriesRequest(), cancellationToken);
        return categories.Select(mapper.Map<CategoryResponse>);
    }
        
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery]CategoryQueryParameters queryParameters, CancellationToken cancellationToken = default)
    {
        if (queryParameters.name is null && queryParameters.id is null)
            return Ok(await GetAllCategoriesAsync(cancellationToken));
        if (queryParameters.id is not null && queryParameters.name is not null)
            return BadRequest("It must contains only one filter");
        if (queryParameters.name is not null)
        {
            var category = await mediator.Send(new GetCategoryByNameRequest(queryParameters.name), cancellationToken);
            if(category is null)
                return NotFound(queryParameters.name);
            return Ok(mapper.Map<CategoryResponse>(category));
        }

        if (queryParameters.id is not null)
        {
            var category = await mediator.Send(new GetCategoryByIdRequest(queryParameters.id ?? 0), cancellationToken);
            if(category is null)
                return NotFound(queryParameters.id);
            return Ok(mapper.Map<CategoryResponse>(category));
        }
        return BadRequest();
    }

    [HttpPost]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateAsync([FromBody]CategoryAddRequest request, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CreateCategoryCommand(mapper.Map<CategoryAddModel>(request)), cancellationToken);
        switch (result)
        {
            case ICreatedResult<CategoryModel> createdResult:
            {
                var category = createdResult.CreatedModel;
                await mediator.Publish(new CategoryCreatedNotification(category), cancellationToken);
                return CreatedAtAction("Get", new { id = category.Id }, mapper.Map<CategoryResponse>(category));
            }
            case CategoryAlreadyExistsResult alreadyExistsResult:
                return BadRequest($"Category with name {alreadyExistsResult.Name} already exists.");
            default:
                return BadRequest();
        }
        
    }
}