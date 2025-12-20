namespace Capstone.Contracts.Authentication;

public record SignUpRequest (
    string FullName,
    string Email,
    string Password,
    string Role
);
    
