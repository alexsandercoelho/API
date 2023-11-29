using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class DistributionRulesController : ControllerBase
{
    private readonly IDistributionRulesService _DistributionRulesService;

    public DistributionRulesController(IDistributionRulesService DistributionRulesService)
    {
        _DistributionRulesService = DistributionRulesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DistributionRulesDto>>> Get()
    {
        var result = await _DistributionRulesService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<DistributionRulesDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _DistributionRulesService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{DistributionRulesId}")]
    public async Task<ActionResult<DistributionRulesDto>> Get(Guid DistributionRulesId)
    {
        var result = await _DistributionRulesService.GetById(DistributionRulesId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<DistributionRulesDto>> Post([FromBody] DistributionRulesDto DistributionRulesDto)
    {
        var result = await _DistributionRulesService.Add(DistributionRulesDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] DistributionRulesDto DistributionRulesDto)
    {
        await _DistributionRulesService.Update(DistributionRulesDto);
        return Ok();
    }

    [HttpDelete("{DistributionRulesId}")]
    public async Task<IActionResult> Delete(Guid DistributionRulesId)
    {
        await _DistributionRulesService.Delete(DistributionRulesId);
        return Ok();
    }
}
