using AutoMapper;
using MediatR;
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
public class RegionsController(IMapper mapper, IMediator mediator) : ControllerBase
{
    
    private async Task<IEnumerable<RegionShortResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await mediator.Send(new GetAllRegionsRequest(), cancellationToken);
        return categories.Select(mapper.Map<RegionShortResponse>);
    }
        
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery]RegionQueryParameters queryParameters, CancellationToken cancellationToken = default)
    {
        if (queryParameters.name is null && queryParameters.id is null)
            return Ok(await GetAllCategoriesAsync(cancellationToken));
        if (queryParameters.id is not null && queryParameters.name is not null)
            return BadRequest("It must contains only one filter");
        if (queryParameters.name is not null)
        {
            var region = await mediator.Send(new GetRegionByNameRequest(queryParameters.name), cancellationToken);
            if(region is null)
                return NotFound(queryParameters.name);
            return Ok(mapper.Map<RegionResponse>(region));
        }

        if (queryParameters.id is not null)
        {
            var region = await mediator.Send(new GetRegionByIdRequest(queryParameters.id ?? 0), cancellationToken);
            if(region is null)
                return NotFound(queryParameters.id);
            return Ok(mapper.Map<RegionResponse>(region));
        }
        return BadRequest();
    }

    [HttpPost]
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
                await mediator.Publish(new RegionCreatedNotification(region), cancellationToken);
                return CreatedAtAction("Get", new { id = region.Id }, mapper.Map<RegionResponse>(region));
            }
            case CountryNotFoundResult  partnerNotFoundResult:
                return NotFound(partnerNotFoundResult.NotFoundId);
            case RegionAlreadyExistsResult regionAlreadyExistsResult:
                return BadRequest($"Region with name {regionAlreadyExistsResult.Name} already exists.");
            default:
                return BadRequest();
        }
    }
    
}