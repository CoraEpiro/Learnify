using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using AppDomain.Exceptions.UserExceptions;
using AppDomain.Interfaces;
using Application.DTO;
using Application.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Persistence;

/// <inheritdoc/>
public class UserRepository : IUserRepository
{
    private readonly LearnifyDbContext _context;
    private readonly ICryptService _cryptService;
    private readonly IJwtService _jwtService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="cryptService">The service for cryptography operations.</param>
    /// <param name="jwtService">The service for JSON Web Token (JWT) operations.</param>
    /// <param name="httpContextAccessor">The accessor for HTTP context.</param>
    public UserRepository(
        LearnifyDbContext context,
        ICryptService cryptService,
        IJwtService jwtService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _context = context;
        _cryptService = cryptService;
        _jwtService = jwtService;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByEmailAsync(string? email)
    {
        var pendingUser = await _context.PendingUsers.FirstOrDefaultAsync(x => x.Email == email);

        if (pendingUser is null)
            pendingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        var user = new User(pendingUser);

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByIdAsync(string? id)
    {
        var pendingUser = await _context.PendingUsers.FindAsync(id);

        if (pendingUser is null)
            pendingUser = await _context.Users.FindAsync(id);

        var user = new User(pendingUser);

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByUsernameAsync(string? username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        return user!;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByUserSecretAsync(string? usersecret)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserSecret == usersecret);

        return user!;
    }

    /// <inheritdoc/>
    public JwtSecurityToken GetTokenFromRequest()
    {
        var authHeader = _httpContextAccessor.HttpContext.Request.Headers[
            "Authorization"
        ].FirstOrDefault();

        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
        {
            var token = authHeader.Substring("Bearer ".Length);
            var tokenHandler = new JwtSecurityTokenHandler();

            if (tokenHandler.CanReadToken(token))
                return tokenHandler.ReadJwtToken(token);
        }

        return null;
    }

    /// <inheritdoc/>
    public async Task<bool> IsEmailExistAsync(string email)
    {
        var user =
            await _context.PendingUsers.FirstOrDefaultAsync(x => x.Email == email)
            ?? await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        return user is not null;
    }

    /// <inheritdoc/>
    public async Task<bool> IsUsernameExistAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        return user is not null;
    }

    /// <inheritdoc/>
    public async Task<UserAuthDto> LogInAsync(string email, string password)
    {
        var user =
            await _context.PendingUsers.FirstOrDefaultAsync(x => x.Email == email)
            ?? await _context.Users.FirstOrDefaultAsync(x => x.Email == email)
            ?? throw new UserNotFoundException(email);

        var isPasswordValid = _cryptService.CheckPassword(password, user.Password);

        if (!isPasswordValid)
            throw new UserInvalidPasswordException(email);

        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email, user.Role);

        user.RefreshToken = token;

        _context.Update(user);
        await _context.SaveChangesAsync();

        var autDto = new UserAuthDto(token, user.Role, user.Email, user.IsProfileBuilt);

        return autDto;
    }

    /// <inheritdoc/>
    public async Task<UserAuthDto> RegisterUserAsync(InsertPendingUserDTO insertUser)
    {
        if (await IsEmailExistAsync(insertUser.Email))
            throw new UserExistException(insertUser.Email);

        var id = IDGeneratorService.GetShortUniqueId();
        var token = _jwtService.GenerateSecurityToken(
            id,
            insertUser.Email,
            AppDomain.Enums.UserRole.Sapling
        );

        var user = _context.PendingUsers
            .Add(
                new PendingUser
                {
                    Id = id,
                    Email = insertUser.Email,
                    Name = insertUser.Name,
                    Password = _cryptService.CryptPassword(insertUser.Password),
                    JoinedTime = DateTime.UtcNow,
                    Role = AppDomain.Enums.UserRole.Sapling,
                    RefreshToken = token
                }
            )
            .Entity;

        await _context.SaveChangesAsync();

        var autDto = new UserAuthDto(token, user.Role, user.Email, user.IsProfileBuilt);

        return autDto;
    }

    /// <inheritdoc/>
    public async Task<User> BuildUserAsync(BuildUserDTO buildUser)
    {
        var userEmail = GetClaimValue("userEmail");
        var pendingUser = _context.PendingUsers.FirstOrDefault(x => x.Email == userEmail);

        var user = new User(pendingUser);
        user.BuildUser(buildUser);
        user.Id = IDGeneratorService.GetUniqueId();
        user.IsProfileBuilt = true;

        var newUser = _context.Users.Add(user).Entity;

        if (newUser is not null)
            _context.PendingUsers.Remove(pendingUser);

        await _context.SaveChangesAsync();

        return newUser;
    }

    /// <inheritdoc/>
    public async Task<string> UpdateTokenAsync()
    {
        var userEmail = GetClaimValue("userEmail");
        var user = _context.PendingUsers.FirstOrDefault(x => x.Email == userEmail);

        if (user is null)
            user = _context.Users.FirstOrDefault(x => x.Email == userEmail);

        var token = _jwtService.GenerateSecurityToken(user.Id, user.Email, user.Role);

        user.RefreshToken = token;

        _context.Update(user);

        await _context.SaveChangesAsync();

        return token;
    }

    /// <inheritdoc/>
    public async Task<User> UpdateUsernameAsync(string id, string newUsername)
    {
        var pendingUser = await GetUserByIdAsync(id);
        var user = new User(pendingUser);
        var usernameExist = await IsUsernameExistAsync(newUsername);

        if (usernameExist)
            throw new Exception("Username already exist");

        user.UserName = newUsername;

        await _context.SaveChangesAsync();

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> UpdatePasswordAsync(string id, string newPassword)
    {
        var pendingUser = await GetUserByIdAsync(id);
        var user = new User(pendingUser);

        user.Password = _cryptService.CryptPassword(newPassword);

        await _context.SaveChangesAsync();

        return user;
    }

    /// <inheritdoc/>
    public async Task<Task> DeleteUserAsync(string id)
    {
        var user = await _context.PendingUsers.FindAsync(id);

        _context.PendingUsers.Remove(user);

        await _context.SaveChangesAsync();

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public async Task<Task> VerifyEmailAsync(string email, string otpCode)
    {
        var verification = _context.EmailVerifications.FirstOrDefault(
            x => x.Email == email && x.OTP == otpCode
        );

        if (verification.ExpireUntil < DateTime.UtcNow)
            return Task.FromResult("OTP is already expired.");

        _context.EmailVerifications.Remove(verification);

        await _context.SaveChangesAsync();

        return Task.FromResult("Your Email is verified.");
    }

    /// <inheritdoc/>
    public async Task<Task> SendOTPCodeAsync(string email)
    {
        var otpCode = OTPCodeGenerator.GenerateOTPCode();

        _context.EmailVerifications.Add(
            new EmailVerification
            {
                Id = IDGeneratorService.GetShortUniqueId(),
                Email = email,
                OTP = otpCode,
                ExpireUntil = DateTime.UtcNow.AddMinutes(2.5)
            }
        );

        await _context.SaveChangesAsync();

        await EmailSender.SendEmailAsync(email, otpCode);

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
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
