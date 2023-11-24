using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ChangesController : ControllerBase
{
    private readonly IChangesService _ChangesService;

    public ChangesController(IChangesService ChangesService)
    {
        _ChangesService = ChangesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChangesDto>>> Get()
    {
        var result = await _ChangesService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<ChangesDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _ChangesService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{ChangesId}")]
    public async Task<ActionResult<ChangesDto>> Get(Guid ChangesId)
    {
        var result = await _ChangesService.GetById(ChangesId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ChangesDto>> Post([FromBody] ChangesDto ChangesDto)
    {
        var result = await _ChangesService.Add(ChangesDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ChangesDto ChangesDto)
    {
        await _ChangesService.Update(ChangesDto);
        return Ok();
    }

    [HttpDelete("{ChangesId}")]
    public async Task<IActionResult> Delete(Guid ChangesId)
    {
        await _ChangesService.Delete(ChangesId);
        return Ok();
    }
}