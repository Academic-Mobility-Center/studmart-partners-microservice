using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.WebHost.Requests.Region;
using StudMart.PartnersMicroservice.WebHost.Responses.Region;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class RegionsController(IMapper mapper) : ControllerBase
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
    public IActionResult Add(RegionAddRequest request)
    {
        int id = 0;
        return Created(nameof(GetById), new[] { id });
    }
    [HttpDelete("{id:int}")]
    public IActionResult Remove(int id)
    {
        return NoContent();
    }
    
}