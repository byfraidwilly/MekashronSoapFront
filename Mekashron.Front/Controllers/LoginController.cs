using Mekashron.Front.Models;
using Mekashron.Front.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace Mekashron.Front.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase 
{
    private readonly ISoapService _soapService;
    private readonly ILogger<LoginController> _logger;

    public LoginController(
        ISoapService soapService, 
        ILogger<LoginController> logger)
    {
        _soapService = soapService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)  // ← Ajoutez [FromBody]
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest(new  // ← Utilisez BadRequest au lieu de Ok
            {
                success = false,
                message = "Email et mot de passe requis"
            });
        }

        _logger.LogInformation("Login attempt for {Email}", request.Email);

        var userData = await _soapService.LoginAsync(request.Email, request.Password);

        if (userData != null)
        {
            _logger.LogInformation("Login successful for {Email}", request.Email);
            return Ok(new
            {
                success = true,
                data = userData,
                message = "Connexion réussie"
            });
        }

        _logger.LogWarning("Login failed for {Email}", request.Email);
        return Unauthorized(new  // ← Utilisez Unauthorized
        {
            success = false,
            message = "Email ou mot de passe incorrect"
        });
    }
}