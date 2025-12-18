namespace Capstone.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult SignUp(string FullName, string Email, string Password);
    AuthenticationResult Login(string Email, string Password);
} 