using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;
using StudMart.PartnersMicroservice.WebHost.Requests.Partner;
using StudMart.PartnersMicroservice.WebHost.Responses.Partner;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class PartnersController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<PartnerShortResponse>> GetAllAsync()
    {
        var partners = await mediator.Send(new GetPartnersRequest());
        return partners.Select(mapper.Map<PartnerShortResponse>);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPartnerByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var partner = await mediator.Send(new GetPartnerRequest(id), cancellationToken);
        return Ok(mapper.Map<PartnerResponse>(partner));
    }
    [HttpPost]
    public async Task<IActionResult> AddPartnerAsync(PartnerAddRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreatePartnerCommand(mapper.Map<PartnerAddModel>(request)), cancellationToken);
        return Created(nameof(GetPartnerByIdAsync), new { id = result.Id });
        
    }
    
}