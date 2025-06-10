using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
[Authorize(Roles = "Admin")]
public class CountriesController(IMapper mapper, IMediator mediator, ILogger<CategoriesController> logger) : ControllerBase
{
    private async Task<IEnumerable<CountryShortResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var countries = await mediator.Send(new GetAllCountriesRequest(), cancellationToken);
        return countries.Select(mapper.Map<CountryShortResponse>);
    }
    /// <summary>
    /// Get list of all countries or country detailed information
    /// </summary>
    /// <param name="queryParameters">Country Id or country name or empty</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of countries or country detailed information or 404 if country with id or name was not found or 400 if error was occured</returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery]CountryQueryParameters queryParameters, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(queryParameters));
        if (queryParameters.name is null && queryParameters.id is null)
            return Ok(await GetAllCategoriesAsync(cancellationToken));
        if (queryParameters.id is not null && queryParameters.name is not null)
        {
            logger.LogError("It must contains only one filter");
            return BadRequest("It must contains only one filter");
        }

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
            if (country is null)
            {
                logger.LogWarning("Country with id {QueryParametersId} not found", queryParameters.id);
                return NotFound(queryParameters.id);
            }

            return Ok(mapper.Map<CountryResponse>(country));
        }
        return BadRequest();
    }
    /// <summary>
    /// Creates new country
    /// </summary>
    /// <param name="request">Country name</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>201 if country was created, 400 if another country has same name or if error was occured</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CountryResponse),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody]CountryAddRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var result = await mediator.Send(new CreateCountryCommand(mapper.Map<CountryAddModel>(request)), cancellationToken);
        switch (result)
        {
            case ICreatedResult<CountryModel> createdResult:
            {
                var country = createdResult.CreatedModel;
                logger.LogInformation("Country with id {CountryId} created", country.Id);
                await mediator.Publish(new CountryCreatedNotification(country), cancellationToken);
                return CreatedAtAction("Get", new { id = country.Id }, mapper.Map<CountryResponse>(createdResult.CreatedModel));
            }
            case CountryAlreadyExistsResult countyExistsResult:
            {
                logger.LogError("Country with name {Name} already exists.", countyExistsResult.Name);
                return BadRequest($"Country with name {countyExistsResult.Name} already exists.");
            }
            default:
            {
                logger.LogError("Error creating country");
                return BadRequest("Error creating country");
            }
        }
    }
}