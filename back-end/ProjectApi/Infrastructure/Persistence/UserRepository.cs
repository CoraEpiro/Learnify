using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private readonly LearnifyDbContext _context;
    private readonly ICryptService _cryptService;

    public UserRepository(LearnifyDbContext context, ICryptService cryptService)
    {
        _context = context;
        _cryptService = cryptService;
    }

    public async Task<PendingUser> GetPendingUserByIdAsync(string? id)
    {
        var pendingUser = await _context.PendingUsers.FirstOrDefaultAsync(x => x.Id == id);

        return pendingUser!;
    }
    public async Task<User> GetUserByEmailAsync(string? email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        return user!;
    }
    public async Task<User> GetUserByIdAsync(string? id)
    {
        var user = await _context.Users.FindAsync(id);

        return user!;
    }
    public async Task<User> GetUserByUsernameAsync(string? username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        return user!;
    }
    public async Task<User> GetUserByUsersecretAsync(string? usersecret)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserSecret == usersecret);

        return user!;
    }
    public async Task<bool> IsEmailExistAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        return user is not null;
    }
    public async Task<bool> IsUsernameExistAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        return user is not null;
    }
    public Task<Task> LogInAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
    public async Task<Task> RegisterUserAsync(InsertPendingUserDTO user)
    {
        _context.PendingUsers.Add(new PendingUser
        {
            Id = IDGeneratorService.GetShortUniqueId(),
            Email = user.Email,
            Name = user.Name,
            Password = _cryptService.CryptPassword(user.Password),
            UserSecret = user.UserSecret,
            JoinedTime = DateTime.UtcNow
        });

        await _context.SaveChangesAsync();

        return Task.CompletedTask;
    }
    public async Task<Task> DeleteUserAsync(string id)
    {
        var user = await _context.PendingUsers.FindAsync(id);

        _context.PendingUsers.Remove(user);

        await _context.SaveChangesAsync();

        return Task.CompletedTask;
    }
    public async Task<User> UpdateUsernameAsync(string id, string newUsername)
    {
        var user = await GetUserByIdAsync(id);
        var usernameExist = await IsUsernameExistAsync(newUsername);

        if(usernameExist)
            throw new Exception("Username already exist");

        user.UserName = newUsername;

        await _context.SaveChangesAsync();

        return user;
    }
    public async Task<User> UpdatePasswordAsync(string id, string newPassword)
    {
        var user = await GetUserByIdAsync(id);

        user.Password = _cryptService.CryptPassword(newPassword);

        await _context.SaveChangesAsync();

        return user;
    }
}