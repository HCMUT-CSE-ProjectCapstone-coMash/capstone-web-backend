namespace Capstone.Application.Services.Authentication;

public record AuthenticationResult (
    Guid Id,
    string FullName,
    string Email,
    string Token,
    DateTime CreatedAt
);