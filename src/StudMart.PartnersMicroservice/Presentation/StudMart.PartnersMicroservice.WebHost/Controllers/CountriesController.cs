using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.WebHost.Requests.Country;
using StudMart.PartnersMicroservice.WebHost.Responses.Country;

namespace StudMart.PartnersMicroservice.WebHost.Controllers;
[ApiController]
[Route("[controller]")]
public class CountriesController(IMapper mapper) : ControllerBase
{
    [HttpGet]
    public IEnumerable<CountryShortResponse> GetAll()
    {
        return [];
    }
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult Add(CountryAddRequest request)
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