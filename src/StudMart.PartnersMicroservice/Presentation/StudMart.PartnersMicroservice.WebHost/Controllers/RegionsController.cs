using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.WebHost.Requests.Region;
using StudMart.PartnersMicroservice.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class RegionsController(IMapper mapper, IMediator mediator) : ControllerBase
{
    [HttpGet]
    public IEnumerable<RegionShortResponse> GetAll()
    {
        return [];
    }
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult Add(RegionAddRequest request, CancellationToken cancellationToken)
    {
        int id = 0;
        return Created(nameof(GetById), new[] { id });
    }
    
}