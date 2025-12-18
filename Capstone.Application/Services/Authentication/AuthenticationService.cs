namespace Capstone.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult SignUp(string FullName, string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(), FullName, Email, "token");
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "Nhon", Email, "token");
    }
}