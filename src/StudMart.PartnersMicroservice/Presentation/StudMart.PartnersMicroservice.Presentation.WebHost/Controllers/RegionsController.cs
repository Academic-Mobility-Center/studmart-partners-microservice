using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Region;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Region;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class RegionsController(IMapper mapper, IMediator mediator, ILogger<RegionsController> logger) : ControllerBase
{
    
    private async Task<IEnumerable<RegionShortResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await mediator.Send(new GetAllRegionsRequest(), cancellationToken);
        return categories.Select(mapper.Map<RegionShortResponse>);
    }
    /// <summary>
    /// Get list of all regions or list of regions by country or region detailed information by region Id or region name
    /// </summary>
    /// <param name="queryParameters">Region Id or region name or country Id or empty</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of all regions or list of regions into country or region detailed information by Id or name or 404 if region with id or name was not found or country with id was not found or 400 if error was occured</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RegionShortResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RegionShortResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync([FromQuery]RegionQueryParameters queryParameters, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(queryParameters));
        if (queryParameters.id is not null && queryParameters.name is not null && queryParameters.countryId is not null)
        {
            logger.LogError("It must contains only one filter for region");
            return BadRequest("It must contains only one filter");
        }

        if (queryParameters.name is null && queryParameters.id is null && queryParameters.countryId is null)
            return Ok(await GetAllCategoriesAsync(cancellationToken));

        if (queryParameters.name is not null)
        {
            var region = await mediator.Send(new GetRegionByNameRequest(queryParameters.name), cancellationToken);
            if(region is null)
                return NotFound($"Region with name {queryParameters.name} is not found");
            return Ok(mapper.Map<RegionResponse>(region));
        }

        if (queryParameters.id is not null)
        {
            var region = await mediator.Send(new GetRegionByIdRequest(queryParameters.id ?? 0), cancellationToken);
            if (region is null)
            {
                logger.LogWarning("Region with id {QueryParametersId} is not found", queryParameters.id);
                return NotFound($"Region with id {queryParameters.id} is not found");
            }

            return Ok(mapper.Map<RegionResponse>(region));
        }

        if (queryParameters.countryId is not null)
        {
            var regions = await mediator.Send(new GetRegionsByCountryRequest(queryParameters.countryId ?? 0), cancellationToken);
            if(regions is null)
                return NotFound("Country with id {countryId} is not found");
            return Ok(regions.Select(mapper.Map<RegionShortResponse>));
        }
        return BadRequest();
    }
    /// <summary>
    /// Creates new region
    /// </summary>
    /// <param name="request">Country Id and region name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>201 if region was created, 404 if country was not found, 400 if region with same name already exists or error was occured</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(RegionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateAsync([FromBody]RegionAddRequest request, CancellationToken cancellationToken)
    {
        var model = mapper.Map<RegionAddModel>(request);
        var result = await mediator.Send(new CreateRegionCommand(model), cancellationToken);
        switch (result)
        {
            case ICreatedResult<RegionModel> createdResult:
            {
                
                var region = createdResult.CreatedModel;
                logger.LogInformation("Region with id {RegionId} created", region.Id);
                await mediator.Publish(new RegionCreatedNotification(region), cancellationToken);
                return CreatedAtAction("Get", new { id = region.Id }, mapper.Map<RegionResponse>(region));
            }
            case CountryNotFoundResult countryNotFoundResult:
            {
                logger.LogWarning("Country with Id {NotFoundId} not found", countryNotFoundResult.NotFoundId);
                return NotFound(countryNotFoundResult.NotFoundId);
            }
            case RegionAlreadyExistsResult regionAlreadyExistsResult:
            {
                logger.LogWarning("Region with name {Name} already exists.", regionAlreadyExistsResult.Name);
                return BadRequest($"Region with name {regionAlreadyExistsResult.Name} already exists.");
            }
            default:
            {
                logger.LogError("Error creating region");
                return BadRequest();
            }
        }
    }
    
}