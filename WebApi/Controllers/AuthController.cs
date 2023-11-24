using Domain.Authentications;
using Domain.Entities;
using Domain.ParametersEntrance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    [Produces("application/json")]
    [HttpPost("/api/CreateToken")]
    public async Task<IActionResult> CreateToken([FromBody] InputModel Input)
    {
        if (string.IsNullOrWhiteSpace(Input.Email) || string.IsNullOrWhiteSpace(Input.Password))
        {
            return Unauthorized();
        }

        var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            var token = new TokenJWTBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-98989889"))
             .AddSubject("Ambiente Teste")
             .AddIssuer("Teste.Securiry.Bearer")
             .AddAudience("Teste.Securiry.Bearer")
             .AddClaim("UsuarioAPINumero", "1")
             .AddExpiry(5)
             .Builder();

            return Ok(token.value);
        }
        else
        {
            return Unauthorized();
        }
    }
}