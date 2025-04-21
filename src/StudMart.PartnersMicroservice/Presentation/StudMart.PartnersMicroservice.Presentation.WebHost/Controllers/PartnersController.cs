using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Partner;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Partner;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;

[ApiController]
[Route("[controller]")]
public class PartnersController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PartnerResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> GetAsync([FromQuery]PartnerQueryParameters queryParameters,
        CancellationToken cancellationToken = default)
    {
        if (queryParameters.id is not null 
            && queryParameters.inn is not null 
            && queryParameters.name is not null 
            && queryParameters.email is not null
            && queryParameters.phone is not null)
            return BadRequest("There is not all filters");
        if (queryParameters.id is not null)
        {
            var partner = await mediator.Send(new GetPartnerByIdRequest(queryParameters.id.Value), cancellationToken);
            if(partner is null)
                return NotFound($"Partner with id {queryParameters.id} not found");
            return Ok(mapper.Map<PartnerResponse>(partner));
        }

        if (queryParameters.name is not null)
        {
            var partner = await mediator.Send(new GetPartnerByNameRequest(queryParameters.name), cancellationToken);
            if(partner is null)
                return NotFound($"Partner with name {queryParameters.name} is not found");
            return Ok(mapper.Map<PartnerResponse>(partner));
            
        }
        if (queryParameters.email is not null)
        {
            var partner = await mediator.Send(new GetPartnerByEmailRequest(queryParameters.email), cancellationToken);
            if(partner is null)
                return NotFound($"Partner with email {queryParameters.email} is not found");
            return Ok(mapper.Map<PartnerResponse>(partner));
            
        }

        if (queryParameters.phone is not null)
        {
            var partner = await mediator.Send(new GetPartnerByPhoneRequest(queryParameters.phone), cancellationToken);
            if(partner is null)
                return NotFound($"Partner with phone {queryParameters.phone} is not found");
            return Ok(mapper.Map<PartnerResponse>(partner));
        }

        if (queryParameters.inn is not null)
        {
            var partner = await mediator.Send(new GetPartnerByInnRequest(queryParameters.inn ?? 0), cancellationToken);
            if(partner is null)
                return NotFound($"Partner with phone {queryParameters.phone} is not found");
            return Ok(mapper.Map<PartnerResponse>(partner));
        }
        var partners = await mediator.Send(new GetAllPartnersRequest(), cancellationToken);
        return Ok(partners.Select(mapper.Map<PartnerShortResponse>));
    }

    [HttpPost]
    [ProducesResponseType(typeof(PartnerResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync([FromBody]PartnerAddRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new CreatePartnerCommand(mapper.Map<PartnerAddModel>(request)),
            cancellationToken);
        switch (result)
        {
            case ICreatedResult<PartnerModel> createdResult:
            {
                var partner = createdResult.CreatedModel;
                await mediator.Publish(new PartnerCreatedNotification(partner), cancellationToken);
                return CreatedAtAction("Get", new { id = partner.Id }, mapper.Map<PartnerResponse>(partner));
            }
            case CountryNotFoundResult countryNotFoundResult:
                return NotFound($"Country with Id {countryNotFoundResult.NotFoundId} not found.");
            case CategoryNotFoundResult categoryNotFound:
                return NotFound($"Category with Id {categoryNotFound.NotFoundId} not found.");
            default:
                return BadRequest();
        }
    }
}