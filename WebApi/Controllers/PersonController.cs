using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _PersonService;

    public PersonController(IPersonService PersonService)
    {
        _PersonService = PersonService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var result = await _PersonService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _PersonService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{PersonId}")]
    public async Task<ActionResult<PersonDto>> Get(Guid PersonId)
    {
        var result = await _PersonService.GetById(PersonId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonDto>> Post([FromBody] PersonDto PersonDto)
    {
        var result = await _PersonService.Add(PersonDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PersonDto PersonDto)
    {
        await _PersonService.Update(PersonDto);
        return Ok();
    }

    [HttpDelete("{PersonId}")]
    public async Task<IActionResult> Delete(Guid PersonId)
    {
        await _PersonService.Delete(PersonId);
        return Ok();
    }
}
