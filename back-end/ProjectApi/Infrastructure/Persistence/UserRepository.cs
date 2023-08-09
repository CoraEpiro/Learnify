using AppDomain.DTOs.User;
using AppDomain.Interfaces;
using Infrastructure.Persistence;

namespace AppDomain.Services;
public class UserRepository : IUserRepository
{
    private readonly LearnifyDbContext _context;

    public UserRepository(LearnifyDbContext context)
    {
        _context = context;
    }

    public Task<UserDTO> GetUserByEmailAsync(string? email)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserByIdAsync(string? id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserByUsernameAsync(string? userName)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserByUsersecretAsync(string? userSecret)
    {
        throw new NotImplementedException();
    }
}