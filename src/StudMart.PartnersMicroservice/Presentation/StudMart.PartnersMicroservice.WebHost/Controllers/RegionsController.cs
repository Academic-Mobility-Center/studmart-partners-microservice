using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Region;
using StudMart.PartnersMicroservice.WebHost.Requests.Region;
using StudMart.PartnersMicroservice.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class RegionsController(IMapper mapper, IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<RegionShortResponse>> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllRegionsRequest(), cancellationToken);
        return result.Select(mapper.Map<RegionShortResponse>);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetRegionByIdRequest(id), cancellationToken);
        return Ok(mapper.Map<RegionResponse>(result));
    }
    [HttpPost]
    public async Task<IActionResult> Add(RegionAddRequest request, CancellationToken cancellationToken)
    {
        var model = mapper.Map<RegionAddModel>(request);
        var result = await mediator.Send(new CreateRegionCommand(model), cancellationToken);
        int id = result.Id;
        return Created(nameof(GetById), new[] { id });
    }
    
}