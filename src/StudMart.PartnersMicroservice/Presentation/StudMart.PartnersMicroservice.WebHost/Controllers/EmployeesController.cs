using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;
using StudMart.PartnersMicroservice.WebHost.Requests.Employee;
using StudMart.PartnersMicroservice.WebHost.Responses.Employee;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeesController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<EmployeeShortResponse>> GetAllEmployeesAsync()
    {
        var employees = await mediator.Send(new GetEmployeesRequest());
        return employees.Select(mapper.Map<EmployeeShortResponse>);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetEmployeeAsync(Guid id)
    {
        var employee = await mediator.Send(new GetEmployeeRequest(id));
        return Ok(mapper.Map<EmployeeResponse>(employee));
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync(EmployeeAddRequest request)
    {
        var employee = await mediator.Send(new CreateEmployeeCommand(mapper.Map<EmployeeAddModel>(request)));
        return Created(nameof(GetEmployeeAsync), new [] { employee.Id });
        
    }
    
}