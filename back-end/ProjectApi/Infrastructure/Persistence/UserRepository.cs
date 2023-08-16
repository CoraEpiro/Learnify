using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using AppDomain.Interfaces;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
    private readonly LearnifyDbContext _context;
    private readonly ICryptService _cryptService;
    private readonly IJwtService _jwtService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserRepository(LearnifyDbContext context, ICryptService cryptService,
                            IJwtService jwtService, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _cryptService = cryptService;
        _jwtService = jwtService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User> GetUserByEmailAsync(string? email)
    {
        var pendingUser = await _context.PendingUsers.FirstOrDefaultAsync(x => x.Email == email);

        if(pendingUser is null)
            pendingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        var user = new User(pendingUser);

        return user;
    }
    public async Task<User> GetUserByIdAsync(string? id)
    {
        var pendingUser = await _context.PendingUsers.FindAsync(id);

        if(pendingUser is null)
            pendingUser = await _context.Users.FindAsync(id);

        var user = new User(pendingUser);

        return user;
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
        var user = await _context.PendingUsers.FirstOrDefaultAsync(x => x.Email == email);

        if (user is not null)
            user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        return user is not null;
    }
    public async Task<bool> IsUsernameExistAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        return user is not null;
    }
    public async Task<TokenID> LogInAsync(string email, string password)
    {
        var user = await _context.PendingUsers.FirstOrDefaultAsync(x => x.Email == email);

        if(user is null)
        {
            user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user is null)
                throw new Exception("User not found");
        }

        var isPasswordValid = _cryptService.CheckPassword(password, user.Password);

        if(!isPasswordValid)
            throw new Exception("Password is not valid");

        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email);

        user.RefreshToken = token;

        _context.Update(user);

        await _context.SaveChangesAsync();

        var tokenID = new TokenID(user.Id, token);

        return tokenID;
    }
    public async Task<string> RegisterUserAsync(InsertPendingUserDTO insertUser)
    {
        var user = _context.PendingUsers.Add(new PendingUser
        {
            Id = IDGeneratorService.GetShortUniqueId(),
            Email = insertUser.Email,
            Name = insertUser.Name,
            Password = _cryptService.CryptPassword(insertUser.Password),
            JoinedTime = DateTime.UtcNow
        }).Entity;

        await _context.SaveChangesAsync();

        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email);

        user.RefreshToken = token;

        _context.Update(user);

        await _context.SaveChangesAsync();

        return token;
    }
    public async Task<User> BuildUserAsync(BuildUserDTO buildUser)
    {
        var userEmail = GetClaimValue("userEmail");
        var pendingUser = _context.PendingUsers.FirstOrDefault(x => x.Email == userEmail);

        var user = new User(pendingUser);
        user.BuildUser(buildUser);
        user.Id = IDGeneratorService.GetUniqueId();
        user.ProfileBuilded = true;

        var newUser = _context.Users.Add(user).Entity;

        if (newUser is not null)
            _context.PendingUsers.Remove(pendingUser);

        await _context.SaveChangesAsync();

        return newUser;
    }
    public async Task<Task> DeleteUserAsync(string id)
    {
        var user = await _context.PendingUsers.FindAsync(id);

        _context.PendingUsers.Remove(user);

        await _context.SaveChangesAsync();

        return Task.CompletedTask;
    }
    public async Task<string> UpdateTokenAsync()
    {
        var userEmail = GetClaimValue("userEmail");
        var user = _context.PendingUsers.FirstOrDefault(x => x.Email == userEmail);

        if(user is null)
            user = _context.Users.FirstOrDefault(x => x.Email == userEmail);

        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email);

        user.RefreshToken = token;

        _context.Update(user);

        await _context.SaveChangesAsync();

        return token;
    }
    public async Task<User> UpdateUsernameAsync(string id, string newUsername)
    {
        var pendingUser = await GetUserByIdAsync(id);
        var user = new User(pendingUser);
        var usernameExist = await IsUsernameExistAsync(newUsername);

        if(usernameExist)
            throw new Exception("Username already exist");

        user.UserName = newUsername;

        await _context.SaveChangesAsync();

        return user;
    }
    public async Task<User> UpdatePasswordAsync(string id, string newPassword)
    {
        var pendingUser = await GetUserByIdAsync(id);
        var user = new User(pendingUser);

        user.Password = _cryptService.CryptPassword(newPassword);

        await _context.SaveChangesAsync();

        return user;
    }
    private JwtSecurityToken GetTokenFromRequest()
    {
        var authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
        {
            var token = authHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();

            if (tokenHandler.CanReadToken(token))
                return tokenHandler.ReadJwtToken(token);
        }

        return null;
    }
    private string GetClaimValue(string claimType)
    {
        var token = GetTokenFromRequest();

        if (token is not null)
        {
            var claim = token.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value;
        }

        return null;
    }
}