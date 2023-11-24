using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EarlyBirdController : ControllerBase
{
    private readonly IEarlyBirdService _EarlyBirdService;

    public EarlyBirdController(IEarlyBirdService EarlyBirdService)
    {
        _EarlyBirdService = EarlyBirdService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EarlyBirdDto>>> Get()
    {
        var result = await _EarlyBirdService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<EarlyBirdDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _EarlyBirdService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{EarlyBirdId}")]
    public async Task<ActionResult<EarlyBirdDto>> Get(Guid EarlyBirdId)
    {
        var result = await _EarlyBirdService.GetById(EarlyBirdId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EarlyBirdDto>> Post([FromBody] EarlyBirdDto EarlyBirdDto)
    {
        var result = await _EarlyBirdService.Add(EarlyBirdDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] EarlyBirdDto EarlyBirdDto)
    {
        await _EarlyBirdService.Update(EarlyBirdDto);
        return Ok();
    }

    [HttpDelete("{EarlyBirdId}")]
    public async Task<IActionResult> Delete(Guid EarlyBirdId)
    {
        await _EarlyBirdService.Delete(EarlyBirdId);
        return Ok();
    }
}