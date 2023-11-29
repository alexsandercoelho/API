using Domain.Common;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly IProfilesService _ProfilesService;

    public ProfilesController(IProfilesService ProfilesService)
    {
        _ProfilesService = ProfilesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProfilesDto>>> Get()
    {
        var result = await _ProfilesService.GetAll();
        return Ok(result);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<ProfilesDto>>> Get([FromQuery] Pagination pagination)
    {
        var result = await _ProfilesService.GetAll(pagination);
        return Ok(result);
    }

    [HttpGet("{ProfilesId}")]
    public async Task<ActionResult<ProfilesDto>> Get(Guid ProfilesId)
    {
        var result = await _ProfilesService.GetById(ProfilesId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProfilesDto>> Post([FromBody] ProfilesDto ProfilesDto)
    {
        var result = await _ProfilesService.Add(ProfilesDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProfilesDto ProfilesDto)
    {
        await _ProfilesService.Update(ProfilesDto);
        return Ok();
    }

    [HttpDelete("{ProfilesId}")]
    public async Task<IActionResult> Delete(Guid ProfilesId)
    {
        await _ProfilesService.Delete(ProfilesId);
        return Ok();
    }
}