using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Employee;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Employee;
using IResult = StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base.IResult;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController(IMediator mediator, IMapper mapper, ILogger<EmployeesController> logger) : ControllerBase
{
    private async Task<IEnumerable<EmployeeShortResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var employees = await mediator.Send(new GetAllEmployeesRequest(), cancellationToken);
        return employees.Select(mapper.Map<EmployeeShortResponse>);
    }
    private ObjectResult MapErrorFromLogicResult(IResult result) => result switch
    {
        PartnerNotFoundResult partnerNotFoundResult => NotFound($"Partner with id {partnerNotFoundResult.NotFoundId} does not exist."),
        EmailAlreadyRegisteredResult emailAlreadyRegisteredResult => BadRequest($"Employee with email {emailAlreadyRegisteredResult.Email} already registered."),
        EmployeeNotFoundResult employeeNotFoundResult => NotFound($"Employee with id {employeeNotFoundResult.NotFoundId} not found."),

    };
    /// <summary>
    /// Get list of employees or employee detailed information
    /// </summary>
    /// <param name="queryParameters">Employee Id or employee email or empty</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of all employees or employee detailed information by Id or Email or 404 if employee was not found by Id or email or 400 if error was occured</returns>
    [HttpGet]
    [ProducesResponseType(typeof(EmployeeResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromQuery] EmployeeQueryParameters queryParameters,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(queryParameters));
        if (queryParameters.email is null && queryParameters.id is null)
            return Ok(await GetAllCategoriesAsync(cancellationToken));
        if (queryParameters.id is not null && queryParameters.email is not null)
        {
            logger.LogError("It must contains only one filter for employee");
            return BadRequest("It must contains only one filter");
        }

        if (queryParameters.email is not null)
        {
            var employee = await mediator.Send(new GetEmployeeByEmailRequest(queryParameters.email), cancellationToken);
            if (employee is null)
                return NotFound(queryParameters.email);
            return Ok(mapper.Map<EmployeeResponse>(employee));
        }

        if (queryParameters.id is not null)
        {
            var employee = await mediator.Send(new GetEmployeeByIdRequest(queryParameters.id ?? Guid.NewGuid()),
                cancellationToken);
            if (employee is null)
            {
                logger.LogWarning("Employee with id {QueryParametersId} not found", queryParameters.id);
                return NotFound(queryParameters.id);
            }

            return Ok(mapper.Map<EmployeeResponse>(employee));
        }

        return BadRequest();
    }
    /// <summary>
    /// Creates new employee
    /// </summary>
    /// <param name="request">Employe firstname, last name, email and partner Id</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>201 if employee was created, 404 if partner was not found, 400 if another employee has same email or if error was occured</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateAsync(EmployeeAddRequest request,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var result = await mediator.Send(new CreateEmployeeCommand(mapper.Map<EmployeeAddModel>(request)),
            cancellationToken);
        if (result is ICreatedResult<EmployeeModel> employeeCreatedResult)
        {
            var employee = employeeCreatedResult.CreatedModel;
            logger.LogInformation("Employee with id {EmployeeId} created", employee.Id);
            await mediator.Publish(new EmployeeCreatedNotification(employee), cancellationToken);
            return CreatedAtAction("Get", new  {id = employee.Id}, mapper.Map<EmployeeResponse>(employee));
        }

        if (result is not InternalErrorResult)
        {
            var response = MapErrorFromLogicResult(result);
            logger.LogWarning(response.Value!.ToString());
            return response;
        }
        logger.LogError("Error creating employee");
        return BadRequest();
    }
    /// <summary>
    /// Updates employee information
    /// </summary>
    /// <param name="id">Employee Id</param>
    /// <param name="request">Employee email, firstname and lastname</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>204 if employee was updated, 404 if employee was not found or partner was not found, 400 if another employee has same email or if error was occured</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync([FromQuery] Guid id, UpdateEmployeeRequest request,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var result = await mediator.Send(new UpdateEmployeeCommand(mapper.Map<UpdateEmployeeModel>(request)), cancellationToken);
        if (result is IUpdatedResult<EmployeeModel> updatedResult)
        {
            logger.LogInformation("Employee with id {Guid} updated", id);
            await mediator.Publish(new EmployeeUpdatedNotification(updatedResult.Model), cancellationToken);
            return NoContent();
        }

        if (result is not InternalErrorResult)
        {

            var response = MapErrorFromLogicResult(result);
            logger.LogWarning(response.Value!.ToString());
            return response;
        }
        logger.LogError("Error was created while update employee");
        return BadRequest();
        
    }
        
}