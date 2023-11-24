using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class FeatureController : ControllerBase
{
    private readonly IFeatureService _FeatureService;

    public FeatureController(IFeatureService FeatureService)
    {
        _FeatureService = FeatureService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeatureDto>>> Get()
    {
        var result = await _FeatureService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<FeatureDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _FeatureService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{FeatureId}")]
    public async Task<ActionResult<FeatureDto>> Get(Guid FeatureId)
    {
        var result = await _FeatureService.GetById(FeatureId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<FeatureDto>> Post([FromBody] FeatureDto FeatureDto)
    {
        var result = await _FeatureService.Add(FeatureDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] FeatureDto FeatureDto)
    {
        await _FeatureService.Update(FeatureDto);
        return Ok();
    }

    [HttpDelete("{FeatureId}")]
    public async Task<IActionResult> Delete(Guid FeatureId)
    {
        await _FeatureService.Delete(FeatureId);
        return Ok();
    }
}