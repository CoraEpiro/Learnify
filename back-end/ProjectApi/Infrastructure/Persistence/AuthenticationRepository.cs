using AppDomain.DTOs.User;
using AppDomain.Interfaces;
using Infrastructure.Persistence;

namespace AppDomain.Services;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly LearnifyDbContext _context;

    private readonly ICryptService _cryptService;

    public AuthenticationRepository(LearnifyDbContext context, ICryptService cryptService)
    {
        _context = context;
        _cryptService = cryptService;
    }

    public Task<bool> IsEmailExistAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUsernameExistAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<Task> LogInAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Task> RegisterAsync(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }
}