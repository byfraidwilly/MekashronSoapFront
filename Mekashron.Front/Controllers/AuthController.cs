using Mekashron.Front.Models;
using Mekashron.Front.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mekashron.Front.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ISoapService _soapService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(ISoapService soapService, ILogger<AuthController> logger)
    {
        _soapService = soapService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return Ok(new
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
        return Ok(new
        {
            success = false,
            message = "Email ou mot de passe incorrect"
        });
    }
}
