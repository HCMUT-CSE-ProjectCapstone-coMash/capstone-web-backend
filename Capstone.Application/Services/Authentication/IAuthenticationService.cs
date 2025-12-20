using Capstone.Application.Common.Result;

namespace Capstone.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<Result<AuthenticationResult>> SignUp(string FullName, string Email, string Password);
    Task<Result<AuthenticationResult>> Login(string Email, string Password);
    Task<Result<AuthenticationResult>> GetUserById(string UserId);
} 