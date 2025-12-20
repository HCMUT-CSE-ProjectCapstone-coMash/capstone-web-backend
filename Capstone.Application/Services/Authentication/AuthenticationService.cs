using Capstone.Application.Common.Interfaces.Authentication;
using Capstone.Application.Common.Interfaces.Persistence;
using Capstone.Application.Common.Interfaces.Services;
using Capstone.Application.Common.Result;
using Capstone.Domain.Entities;

namespace Capstone.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordhasher;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher, IDateTimeProvider dateTimeProvider, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordhasher = passwordHasher;
        _dateTimeProvider = dateTimeProvider;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> SignUp(string FullName, string Email, string Password)
    {
        if (await _userRepository.GetUserByEmail(Email) is not null)
        {
            return Result<AuthenticationResult>.Failure("User with given email already exists.");
        }

        var user = new User
        {
            FullName = FullName,
            Email = Email,
            Password = _passwordhasher.Hash(Password),
            CreatedAt = _dateTimeProvider.UtcNow
        };

        await _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user.Id, FullName);

        return Result<AuthenticationResult>.Success(new AuthenticationResult(user.Id, FullName, Email, token, user.CreatedAt));
    }

    public async Task<Result<AuthenticationResult>> Login(string Email, string Password)
    {
        var user = await _userRepository.GetUserByEmail(Email);

        if (user is null || !_passwordhasher.Verify(Password, user.Password))
        {
            return Result<AuthenticationResult>.Failure("Invalid email or password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FullName);

        return Result<AuthenticationResult>.Success(new AuthenticationResult(user.Id, user.FullName, user.Email, token, user.CreatedAt));
    }

    public async Task<Result<AuthenticationResult>> GetUserById(string UserId)
    {
        var user = await _userRepository.GetUserById(Guid.Parse(UserId));

        if (user is null)
        {
            return Result<AuthenticationResult>.Failure(".");
        }

        return Result<AuthenticationResult>.Success(new AuthenticationResult(user.Id, user.FullName, user.Email, "", user.CreatedAt));
    }
}