using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Region;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Partner;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Employee;
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
    /// <summary>
    /// Get list of all partners or partner detailed information by Id, name, inn, email, phone
    /// </summary>
    /// <param name="queryParameters">Id or name or inn or  email or phone or empty </param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of all partners or partner detailed information by ID or name or inn or  email or phone or 404 if partner was not found by Id or name or inn or  email or phone or 400 if error was occured</returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
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
    /// <summary>
    /// Creates new partner
    /// </summary>
    /// <param name="request">Partner information</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>201 if partner was created or 404 if category or country was not found, 400 if partner with same Inn, phone, email, name already exists or if error was occured</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
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
    /// <summary>
    /// Updates partner information
    /// </summary>
    /// <param name="id">Partner Id</param>
    /// <param name="request">Partner information</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>204 if partner was partner  or 404 if category or country or partner was not found, 400 if another partner with same Inn, phone, email, name already exists or if error was occured</returns>
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

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(id));
        logger.LogInformation($"Try processing delete partner with id {id}.");
        
        var partner = await mediator.Send(new GetPartnerByIdRequest(id), cancellationToken);

        if (partner is null)
        {
            return NotFound($"Partner with id {id} is not found");
        }
        
        var employees = await mediator.Send(new GetAllEmployeesRequest(), cancellationToken);
        var employeesForDelete = employees.Where(w => w.Partner.Id == partner.Id);
        
        logger.LogInformation("Try found employees partner in table 'Employees'.");

        if (!employeesForDelete.Any())
        {
            logger.LogWarning("Employees for delete by partner with id {Guid} not found.", id);
        }

        foreach (var employee in employeesForDelete)
        {
            var empDeleteResult = await mediator.Send(new DeleteEmployeeCommand(employee.Id), cancellationToken);

            if (empDeleteResult is ISuccessResult)
            {
                logger.LogInformation("Successfully deleted partner employee with id {EmployeeId}.", employee.Id);
                continue;
            }

            if (empDeleteResult is EmployeeNotFoundResult)
            {
                logger.LogInformation("Not found partner employee with id {EmployeeId}.", employee.Id);
            }
        }
        
        logger.LogInformation("Try found and delete PartnerRegions in table 'PartnerRegion'.");
        
        var deletedPartnerRegionsResult = await mediator.Send(new DeletePartnerRegionsCommand(partner.Id), cancellationToken);
        
        logger.LogInformation(deletedPartnerRegionsResult is ISuccessResult
            ? "Successfully deleted partner regions. Try to delete partner. "
            : "Not found partner regions. Try to delete partner.");
        
        var deletePartnerResult = await mediator.Send(new DeletePartnerCommand(partner.Id), cancellationToken);

        if (deletePartnerResult is ISuccessResult)
        {
            logger.LogInformation("Successfully deleted partner with id {PartnerId}.",  partner.Id);
            return NoContent();
        }
        
        var response = MapErrorFromLogicResult(deletePartnerResult);
        logger.LogWarning(response.Value!.ToString());
        return response;
    }
}