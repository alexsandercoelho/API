using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class FlagController : ControllerBase
{
    private readonly IFlagService _FlagService;

    public FlagController(IFlagService FlagService)
    {
        _FlagService = FlagService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlagDto>>> Get()
    {
        var result = await _FlagService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<FlagDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _FlagService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{FlagId}")]
    public async Task<ActionResult<FlagDto>> Get(Guid FlagId)
    {
        var result = await _FlagService.GetById(FlagId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<FlagDto>> Post([FromBody] FlagDto FlagDto)
    {
        var result = await _FlagService.Add(FlagDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] FlagDto FlagDto)
    {
        await _FlagService.Update(FlagDto);
        return Ok();
    }

    [HttpDelete("{FlagId}")]
    public async Task<IActionResult> Delete(Guid FlagId)
    {
        await _FlagService.Delete(FlagId);
        return Ok();
    }
}