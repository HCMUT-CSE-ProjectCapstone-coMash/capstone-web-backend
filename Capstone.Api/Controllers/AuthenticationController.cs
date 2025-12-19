using Capstone.Application.Services.Authentication;
using Capstone.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
namespace Capstone.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(SignUpRequest request)
    {
        var result = await _authenticationService.SignUp(request.FullName, request.Email, request.Password);

        if (!result.IsSuccess)
        {
            return Conflict(new { error = result.Error });
        }

        var authResult = result.Value!;

        return Ok(new AuthenticationResponse(
            authResult.Id,
            authResult.FullName,
            authResult.Email,
            authResult.Token,
            authResult.CreatedAt
        ));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _authenticationService.Login(request.Email, request.Password);

        if (!result.IsSuccess)
        {
            return Conflict(new { error = result.Error });
        }

        var authResult = result.Value!;

        return Ok(new AuthenticationResponse(
            authResult.Id,
            authResult.FullName,
            authResult.Email,
            authResult.Token,
            authResult.CreatedAt
        ));
    }
}