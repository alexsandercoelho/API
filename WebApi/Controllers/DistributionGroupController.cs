using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class DistributionGroupController : ControllerBase
{
    private readonly IDistributionGroupService _DistributionGroupService;

    public DistributionGroupController(IDistributionGroupService DistributionGroupService)
    {
        _DistributionGroupService = DistributionGroupService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DistributionGroupDto>>> Get()
    {
        var result = await _DistributionGroupService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<DistributionGroupDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _DistributionGroupService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{DistributionGroupId}")]
    public async Task<ActionResult<DistributionGroupDto>> Get(Guid DistributionGroupId)
    {
        var result = await _DistributionGroupService.GetById(DistributionGroupId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<DistributionGroupDto>> Post([FromBody] DistributionGroupDto DistributionGroupDto)
    {
        var result = await _DistributionGroupService.Add(DistributionGroupDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] DistributionGroupDto DistributionGroupDto)
    {
        await _DistributionGroupService.Update(DistributionGroupDto);
        return Ok();
    }

    [HttpDelete("{DistributionGroupId}")]
    public async Task<IActionResult> Delete(Guid DistributionGroupId)
    {
        await _DistributionGroupService.Delete(DistributionGroupId);
        return Ok();
    }
}
