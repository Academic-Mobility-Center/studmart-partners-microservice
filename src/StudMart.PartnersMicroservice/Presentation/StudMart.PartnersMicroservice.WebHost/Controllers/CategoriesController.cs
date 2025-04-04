using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Category;
using StudMart.PartnersMicroservice.WebHost.Requests.Category;
using StudMart.PartnersMicroservice.WebHost.Responses.Category;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriesController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CategoryResponse>> GetAllAsync(CancellationToken token = default)
    {
        var categories = await mediator.Send(new GetAllCategoriesRequest(), token);
        return categories.Select(mapper.Map<CategoryResponse>); 
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var category = await mediator.Send(new GetCategoryByIdRequest(id), cancellationToken);
        return Ok(mapper.Map<CategoryResponse>(category));
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryAddRequest category, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CreateCategoryCommand(mapper.Map<CategoryAddModel>(category)), cancellationToken);
        return CreatedAtAction("GetById", new { id = result.Id }, mapper.Map<CategoryResponse>(result));
    }
}