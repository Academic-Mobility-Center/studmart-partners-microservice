using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.WebHost.Requests.Country;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class CountriesController(IMapper mapper, IMediator mediator) : ControllerBase
{
    [HttpGet]
    public IEnumerable<CountryShortResponse> GetAll()
    {
        return [];
    }
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> Add(CountryAddRequest request, CancellationToken cancellationToken)
    {
        var country = await mediator.Send(new CreateCountryCommand(mapper.Map<CountryAddModel>(request)), cancellationToken);
        return Created(nameof(GetById), new[] { country.Id });
    }
}