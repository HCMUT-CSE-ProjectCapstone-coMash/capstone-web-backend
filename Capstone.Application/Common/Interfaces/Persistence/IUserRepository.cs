namespace Capstone.Application.Common.Interfaces.Persistence;
using Capstone.Domain.Entities;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task AddUser(User user);
    Task<User?> GetUserById(Guid userId);
}
