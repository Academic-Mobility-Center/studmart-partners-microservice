using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Country;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Country;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Country;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class CountriesController(IMapper mapper, IMediator mediator) : ControllerBase
{
    private async Task<IEnumerable<CountryShortResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var countries = await mediator.Send(new GetAllCountriesRequest(), cancellationToken);
        return countries.Select(mapper.Map<CountryShortResponse>);
    }
        
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery]CountryQueryParameters queryParameters, CancellationToken cancellationToken = default)
    {
        if (queryParameters.name is null && queryParameters.id is null)
            return Ok(await GetAllCategoriesAsync(cancellationToken));
        if (queryParameters.id is not null && queryParameters.name is not null)
            return BadRequest("It must contains only one filter");
        if (queryParameters.name is not null)
        {
            var country = await mediator.Send(new GetCountryByNameRequest(queryParameters.name), cancellationToken);
            if(country is null)
                return NotFound(queryParameters.name);
            return Ok(mapper.Map<CountryResponse>(country));
        }

        if (queryParameters.id is not null)
        {
            var country = await mediator.Send(new GetCountryByIdRequest(queryParameters.id ?? 0), cancellationToken);
            if(country is null)
                return NotFound(queryParameters.id);
            return Ok(mapper.Map<CountryResponse>(country));
        }
        return BadRequest();
    }
    [HttpPost]
    [ProducesResponseType(typeof(CountryResponse),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody]CountryAddRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreateCountryCommand(mapper.Map<CountryAddModel>(request)), cancellationToken);
        switch (result)
        {
            case ICreatedResult<CountryModel> createdResult:
            {
                var country = createdResult.CreatedModel;
                await mediator.Publish(new CountryCreatedNotification(country), cancellationToken);
                return CreatedAtAction("Get", new { id = country.Id }, mapper.Map<CountryResponse>(createdResult.CreatedModel));
            }
            case CountryAlreadyExistsResult countyExistsResult:
                return BadRequest($"Country with name {countyExistsResult.Name} already exists.");
            default:
                return BadRequest();
        }
    }
}