using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class FuncionalityController : ControllerBase
{
    private readonly IFuncionalityService _FuncionalityService;

    public FuncionalityController(IFuncionalityService FuncionalityService)
    {
        _FuncionalityService = FuncionalityService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuncionalityDto>>> Get()
    {
        var result = await _FuncionalityService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<FuncionalityDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _FuncionalityService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{FuncionalityId}")]
    public async Task<ActionResult<FuncionalityDto>> Get(Guid FuncionalityId)
    {
        var result = await _FuncionalityService.GetById(FuncionalityId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<FuncionalityDto>> Post([FromBody] FuncionalityDto FuncionalityDto)
    {
        var result = await _FuncionalityService.Add(FuncionalityDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] FuncionalityDto FuncionalityDto)
    {
        await _FuncionalityService.Update(FuncionalityDto);
        return Ok();
    }

    [HttpDelete("{FuncionalityId}")]
    public async Task<IActionResult> Delete(Guid FuncionalityId)
    {
        await _FuncionalityService.Delete(FuncionalityId);
        return Ok();
    }
}
