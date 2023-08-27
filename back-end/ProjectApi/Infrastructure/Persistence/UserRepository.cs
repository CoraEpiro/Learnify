using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using AppDomain.Exceptions.UserExceptions;
using AppDomain.Interfaces;
using AppDomain.Responses;
using AppDomain.ValueObjects;
using Application.DTO;
using Application.Services;
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
    private readonly IEmailService _emailService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class with the required dependencies.
    /// </summary>
    /// <param name="context">The database context for data access.</param>
    /// <param name="cryptService">Service for cryptographic operations.</param>
    /// <param name="jwtService">Service for JSON Web Token operations.</param>
    /// <param name="httpContextAccessor">Accessor for HTTP context-related information.</param>
    /// <param name="emailService">Service for sending emails.</param>
    public UserRepository(
        LearnifyDbContext context,
        ICryptService cryptService,
        IJwtService jwtService,
        IHttpContextAccessor httpContextAccessor,
        IEmailService emailService)
    {
        _context = context;
        _cryptService = cryptService;
        _jwtService = jwtService;
        _httpContextAccessor = httpContextAccessor;
        _emailService = emailService;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByIdAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);

        if(user is null)
            throw new UserNotFoundException("GetUserByIdAsync");

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        if (user is null)
            throw new UserNotFoundException("GetUserByEmailAsync");

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        if (user is null)
            throw new UserNotFoundException("GetUserByUsernameAsync");

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByUserSecretAsync(string usersecret)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserSecret == usersecret);

        if (user is null)
            throw new UserNotFoundException("GetUserByUserSecretAsync");

        return user!;
    }

    /// <inheritdoc/>
    public async Task<UserResponsePublishedCounts> GetUserResponsePublishedCountsAsync(string userId)
    {
        var counts = new UserResponsePublishedCounts();

        counts.PublishedAnswerCount = await _context.Answers.CountAsync(x => x.UserId == userId);
        counts.PublishedArticlesCount = await _context.Articles.CountAsync(x => x.UserId == userId);
        counts.PublishedQuestionCount = await _context.Questions.CountAsync(x => x.UserId == userId);

        return counts;
    }

    /// <inheritdoc/>
    public async Task<UserProfile> GetUserProfileAsync()
    {
        var userId = GetClaimValue("userId");

        var user = await GetUserByIdAsync(userId);

        var profile = ModelConvertors.ToUserProfile(user);

        return profile;
    }

    /// <inheritdoc/>
    public async Task<bool> IsUsernameExistAsync(string username)
    {
        try
        {
            var user = await GetUserByUsernameAsync(username);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
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

        if(user is null)
            throw new UserNotFoundException("UpdateTokenAsync");

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
            throw new Exception("Username already exists.");

        user.UserName = newUsername;

        await _context.SaveChangesAsync();

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> UpdatePasswordAsync(string newPassword)
    {
        var userId = GetClaimValue("userId");

        if(userId is null)
            throw new Exception("Something went wrong.");

        var user = await GetUserByIdAsync(userId);

        if(user is null)
            throw new UserNotFoundException("Update Password");

        user.Password = _cryptService.CryptPassword(newPassword);

        _context.Update(user);

        await _context.SaveChangesAsync();

        return user;
    }

    /// <inheritdoc/>
    public async Task<Task> RenewPasswordAsync(string email, string newPassword)
    {
        var user = await GetUserByEmailAsync(email);

        user.Password = _cryptService.CryptPassword(newPassword);

        _context.Update(user);

        await _context.SaveChangesAsync();

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public async Task<PersonalInfoResponse> UpdatePersonalInfoAsync(PersonalInfoResponse response)
    {
        var userId = GetClaimValue("userId");

        var personalInfoResponse = new PersonalInfoResponse();
        var user = await GetUserByIdAsync(userId);
        var personalInfo = user.PersonalInfo;
        var newPersonalInfo = response.PersonalInfo;

        personalInfo.Bio = newPersonalInfo.Bio ?? personalInfo.Bio;
        personalInfo.Work = newPersonalInfo.Work ?? personalInfo.Work;
        personalInfo.Location = newPersonalInfo.Location ?? personalInfo.Location;
        personalInfo.Education = newPersonalInfo.Education ?? personalInfo.Education;
        personalInfo.WebsiteUrl = newPersonalInfo.WebsiteUrl ?? personalInfo.WebsiteUrl;
        personalInfo.DisplayEmail = newPersonalInfo.DisplayEmail ?? personalInfo.DisplayEmail;
        personalInfo.AvailableFor = newPersonalInfo.AvailableFor ?? personalInfo.AvailableFor;
        personalInfo.PinnedArticles = newPersonalInfo.PinnedArticles ?? personalInfo.PinnedArticles;
        personalInfo.CurrentlyWorking = newPersonalInfo.CurrentlyWorking ?? personalInfo.CurrentlyWorking;
        personalInfo.PinnedRepositories = newPersonalInfo.PinnedRepositories ?? personalInfo.PinnedRepositories;

        user.PersonalInfo = personalInfo;
        //user.ConnectedAccountList = response.ConnectedAccountList;

         _context.Update(user);

        await _context.SaveChangesAsync();

        personalInfoResponse.PersonalInfo = personalInfo;
        //personalInfoResponse.ConnectedAccountList = user.ConnectedAccountList;

        return personalInfoResponse;
    }

    /// <inheritdoc/>
    public async Task<UserProfile> UpdateProfileAsync(UserProfile profile)
    {
        var userId = GetClaimValue("userId");

        var user = await GetUserByIdAsync(userId);

        user.Name = profile.Name ?? user.Name;
        user.UserName = profile.Username ?? user.UserName;
        user.Email = profile.Email ?? user.Email;
        user.ProfilePhoto = profile.ProfilePhoto ?? user.ProfilePhoto;

        var newUserProfile = new UserProfile
        {
            Name = user.Name,
            Email = user.Email,
            Username = user.UserName,
            ProfilePhoto = user.ProfilePhoto
        };

        _context.Update(user);

        await _context.SaveChangesAsync();

        return newUserProfile;
    }

    /// <inheritdoc/>
    public async Task<Customization> UpdateCustomizationAsync(Customization customization)
    {
        var userId = GetClaimValue("userId");

        var user = await GetUserByIdAsync(userId);

        var settings = user.Settings;
        var newSettings = customization.Settings;

        settings.ContentPerPage = newSettings.ContentPerPage;
        settings.IsTwoFactorActivated = newSettings.IsTwoFactorActivated;
        settings.Font = newSettings.Font;
        settings.Theme = newSettings.Theme;

        var brand = user.Brand;
        var newBrand = customization.Brand;

        brand.BannerPhoto = newBrand.BannerPhoto;
        brand.AccentColor = newBrand.AccentColor;

        user.Settings = settings;
        user.Brand = brand;

        var savedUser = _context.Update(user).Entity;

        await _context.SaveChangesAsync();

        if(savedUser is null)
            throw new DbUpdateException("Something went wrong during UpdateCustomizationAsync process.");

        var newCustomization = new Customization()
        {
            Settings = savedUser.Settings,
            Brand = savedUser.Brand
        };

        return newCustomization;
    }

    /// <inheritdoc/>
    public async Task<User> DeleteUserAsync(string id)
    {
        var user = await GetUserByIdAsync(id);

        if (user is null)
            throw new UserNotFoundException("Delete");

        user.IsDeleted = true;

        await _context.SaveChangesAsync();

        return user;
    }

    private async Task<User> RemoveUserAsync(string id)
    {
        var pendingUser = await _context.PendingUsers.FindAsync(id);

        if (pendingUser is not null)
        {
            pendingUser = _context.PendingUsers.Remove(pendingUser).Entity;

            await _context.SaveChangesAsync();

            return pendingUser is null ? null : new User(pendingUser);
        }
        else
        {
            var user = await _context.Users.FindAsync(id);

            user = _context.Users.Remove(user).Entity;

            await _context.SaveChangesAsync();

            return user is null ? null : user;
        }

    }

    /// <inheritdoc/>
    public async Task<Customization> GetCustomizationAsync()
    {
        var userId = GetClaimValue("userId");

        var user = await GetUserByIdAsync(userId);

        var customization = new Customization();

        customization.Settings = user.Settings;
        customization.Brand = user.Brand;

        return customization;
    }

    /// <inheritdoc/>
    public async Task<PersonalInfoResponse> GetPersonalInfoAsync()
    {
        var userId = GetClaimValue("userId");

        var user = await GetUserByIdAsync(userId);

        var personalInfo = new PersonalInfoResponse();
        personalInfo.PersonalInfo = user.PersonalInfo;
        //personalInfo.ConnectedAccountList = user.ConnectedAccountList;

        return personalInfo;
    }

    /// <inheritdoc/>
    public async Task<string> DeleteEmailVerificationAsync(string email, string otpCode)
    {
        try
        {
            var verification = await _emailService.VerifyEmailAsync(email, otpCode);

            _context.EmailVerifications.Remove(verification);

            await _context.SaveChangesAsync();

            return email;
        }
        catch (Exception)
        {
            throw;
        }
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

        await _emailService.SendEmailAsync(email, otpCode);

        return Task.CompletedTask;
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
    private string GetClaimValue(string claimType)
    {
        var token = GetTokenFromRequest();

        if (token is null)
            throw new UnauthorizedAccessException("Token is null");

        var claim = token.Claims.FirstOrDefault(c => c.Type == claimType);
        return claim?.Value;
    }

    /// <inheritdoc/>
    private JwtSecurityToken GetTokenFromRequest()
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
}