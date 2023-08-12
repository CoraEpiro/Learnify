using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private readonly LearnifyDbContext _context;
    private readonly ICryptService _cryptService;
    private readonly IJwtService _jwtService;

    public UserRepository(LearnifyDbContext context, ICryptService cryptService, IJwtService jwtService)
    {
        _context = context;
        _cryptService = cryptService;
        _jwtService = jwtService;
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
    public async Task<string> LogInAsync(string email, string password)
    {
        var user = await _context.PendingUsers.FirstOrDefaultAsync(x => x.Email == email);

        if(user is null)
            throw new Exception("User not found");

        var isPasswordValid = _cryptService.CheckPassword(password, user.Password);

        if(!isPasswordValid)
            throw new Exception("Password is not valid");

        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email);

        return token;
    }
    public async Task<string> RegisterUserAsync(InsertPendingUserDTO insertUser)
    {
        var user = _context.PendingUsers.Add(new PendingUser
        {
            Id = IDGeneratorService.GetShortUniqueId(),
            Email = insertUser.Email,
            Name = insertUser.Name,
            Password = _cryptService.CryptPassword(insertUser.Password),
            UserSecret = insertUser.UserSecret,
            JoinedTime = DateTime.UtcNow
        }).Entity;

        await _context.SaveChangesAsync();

        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email);

        return token;
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