using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Country;
using StudMart.PartnersMicroservice.WebHost.Requests.Country;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class CountriesController(IMapper mapper, IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CountryShortResponse>> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllCountriesRequest(), cancellationToken);
        return result.Select(mapper.Map<CountryShortResponse>);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetCountryRequest(id), cancellationToken);
        return Ok(mapper.Map<CountryResponse>(result));
    }
    [HttpPost]
    public async Task<IActionResult> Add(CountryAddRequest request, CancellationToken cancellationToken)
    {
        var country = await mediator.Send(new CreateCountryCommand(mapper.Map<CountryAddModel>(request)), cancellationToken);
        return Created(nameof(GetById), new[] { country.Id });
    }
}