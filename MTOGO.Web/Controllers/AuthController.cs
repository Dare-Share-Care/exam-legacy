using Microsoft.AspNetCore.Mvc;
using MTOGO.Web.Interfaces.DomainServices;
using MTOGO.Web.Models.Dto;

namespace MTOGO.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        await _authService.LoginAsync(dto);
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        await _authService.RegisterAsync(dto);
        return Ok();
    }
}