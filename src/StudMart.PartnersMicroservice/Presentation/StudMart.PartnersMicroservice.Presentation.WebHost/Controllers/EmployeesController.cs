using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Employee;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Employee;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private async Task<IEnumerable<EmployeeShortResponse>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var employees = await mediator.Send(new GetAllEmployeesRequest(), cancellationToken);
        return employees.Select(mapper.Map<EmployeeShortResponse>);
    }

    [HttpGet]
    [ProducesResponseType(typeof(EmployeeResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromQuery] EmployeeQueryParameters queryParameters,
        CancellationToken cancellationToken = default)
    {
        if (queryParameters.email is null && queryParameters.id is null)
            return Ok(await GetAllCategoriesAsync(cancellationToken));
        if (queryParameters.id is not null && queryParameters.email is not null)
            return BadRequest("It must contains only one filter");
        if (queryParameters.email is not null)
        {
            var employee = await mediator.Send(new GetEmployeeByEmailRequest(queryParameters.email), cancellationToken);
            if (employee is null)
                return NotFound(queryParameters.email);
            return Ok(mapper.Map<EmployeeShortResponse>(employee));
        }

        if (queryParameters.id is not null)
        {
            var employee = await mediator.Send(new GetEmployeeByIdRequest(queryParameters.id ?? Guid.NewGuid()),
                cancellationToken);
            if (employee is null)
                return NotFound(queryParameters.id);
            return Ok(mapper.Map<EmployeeShortResponse>(employee));
        }

        return BadRequest();
    }

    [HttpPost]
    [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateAsync(EmployeeAddRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CreateEmployeeCommand(mapper.Map<EmployeeAddModel>(request)),
            cancellationToken);
        switch (result)
        {
            case ICreatedResult<EmployeeModel> createdResult:
            {
                var employee = mapper.Map<Employee>(createdResult);
                return CreatedAtAction("Get", new { id = employee.Id }, mapper.Map<EmployeeResponse>(employee));
            }
            case PartnerNotFoundResult:
                return NotFound($"Partner with id {request.PartnerId} does not exist.");
            case EmailAlreadyRegisteredResult:
                return BadRequest($"Employee with email {request.Email} already registered.");
            default:
                return BadRequest();
        }
    }
}