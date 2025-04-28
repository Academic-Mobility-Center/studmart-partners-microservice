using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Partner;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Partner;
using IResult = StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base.IResult;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;

[ApiController]
[Route("[controller]")]
public class PartnersController(IMediator mediator, IMapper mapper, ILogger<PartnersController> logger) : ControllerBase
{
    private ObjectResult MapErrorFromLogicResult(IResult result) => result switch
    {
        CountryNotFoundResult countryNotFoundResult => NotFound($"Country with Id {countryNotFoundResult.NotFoundId} not found."),
        CategoryNotFoundResult categoryNotFound => NotFound($"Category with Id {categoryNotFound.NotFoundId} not found."),
        PartnerAlreadyRegisteredResult partnerAlreadyRegisteredResult => BadRequest($"Partner with inn {partnerAlreadyRegisteredResult.Inn} already registered."),
        PartnerPhoneAlreadyRegisteredResult partnerPhoneAlreadyRegisteredResult => BadRequest($"Partner with Phone {partnerPhoneAlreadyRegisteredResult.Phone} already registered."),
        PartnerEmailAlreadyRegisteredResult partnerEmailAlreadyRegisteredResult => BadRequest($"Partner with Email {partnerEmailAlreadyRegisteredResult.Email} already registered."),
        PartnerNameAlreadyRegisteredResult partnerNameAlreadyRegisteredResult => BadRequest($"Partner with Name {partnerNameAlreadyRegisteredResult.Name} already registered."),
        PartnerNotFoundResult partnerNotFoundResult => NotFound($"Partner with Id {partnerNotFoundResult.NotFoundId} not found.")
    };
    [HttpGet]
    [ProducesResponseType(typeof(PartnerResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> GetAsync([FromQuery]PartnerQueryParameters queryParameters,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(queryParameters));
        if (queryParameters.id is not null
            && queryParameters.inn is not null
            && queryParameters.name is not null
            && queryParameters.email is not null
            && queryParameters.phone is not null)
        {
            logger.LogError("There is not all filters for partner");
            return BadRequest("There is not all filters");
        }

        if (queryParameters.id is not null)
        {
            var partner = await mediator.Send(new GetPartnerByIdRequest(queryParameters.id.Value), cancellationToken);
            if (partner is null)
            {
                logger.LogWarning("Partner with id {QueryParametersId} not found", queryParameters.id);
                return NotFound($"Partner with id {queryParameters.id} not found");
            }

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
            var partner = await mediator.Send(new GetPartnerByPhoneRequest(queryParameters.phone.Trim()[0]== '+' ? queryParameters.phone.Trim() : $"+{queryParameters.phone.Trim()}"), cancellationToken);
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
        logger.LogInformation(JsonSerializer.Serialize(request));
        var result = await mediator.Send(new CreatePartnerCommand(mapper.Map<PartnerAddModel>(request)),
            cancellationToken);
        if (result is ICreatedResult<PartnerModel> createdResult)
        {
            var partner = createdResult.CreatedModel;
            logger.LogInformation("Partner with id {PartnerId} added", partner.Id);
            await mediator.Publish(new PartnerCreatedNotification(partner), cancellationToken);
            return CreatedAtAction("Get",  new { id = partner.Id }, mapper.Map<PartnerResponse>(partner));
        }

        if (result is not InternalErrorResult)
        {
            var response = MapErrorFromLogicResult(result);
            logger.LogWarning(response.Value!.ToString());
            return response;
        }
        logger.LogError("Error creating partner");
        return BadRequest();
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> UpdateAsync([FromQuery] Guid id, UpdatePartnerRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var result = await mediator.Send(new UpdatePartnerCommand(mapper.Map<UpdatePartnerModel>(request)),
            cancellationToken);
        if (result is IUpdatedResult<PartnerModel> updatedResult)
        {
            logger.LogInformation("Partner with id {Guid} updated", id);
            await mediator.Publish(new PartnerUpdatedNotification(updatedResult.Model), cancellationToken);
            return NoContent();
        }

        if (result is not InternalErrorResult)
        {
            var response = MapErrorFromLogicResult(result);
            logger.LogWarning(response.Value!.ToString());
            return response;
        }
        logger.LogError("Error creating partner");
        return BadRequest();
        
    }
}