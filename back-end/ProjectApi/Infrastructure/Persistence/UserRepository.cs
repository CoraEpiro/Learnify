using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using AppDomain.Exceptions.UserExceptions;
using AppDomain.Interfaces;
using AppDomain.Responses;
using AppDomain.ValueObjects;
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

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        return user;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);

        return user!;
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByUserSecretAsync(string usersecret)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserSecret == usersecret);

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

        if (userId is null)
            return null;

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

        var profile = ModelConvertors.ToUserProfile(user);

        return profile;
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

        if (userEmail is null)
            return null;

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

        if (userEmail is null)
            return null;

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
    public async Task<PersonalInfoResponse> UpdatePersonalInfoAsync(PersonalInfoResponse response)
    {
        var userId = GetClaimValue("userId");

        if (userId is null)
            return null;

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
        user.ConnectedAccountList = response.ConnectedAccountList;

         _context.Update(user);

        await _context.SaveChangesAsync();

        personalInfoResponse.PersonalInfo = personalInfo;
        personalInfoResponse.ConnectedAccountList = user.ConnectedAccountList;

        return personalInfoResponse;
    }

    /// <inheritdoc/>
    public async Task<UserProfile> UpdateProfileAsync(UserProfile profile)
    {
        var userId = GetClaimValue("userId");

        if(userId is null)
            return null;

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

        if (userId is null)
            return null;

        var user = await GetUserByIdAsync(userId);

        if(user is null)
            return null;

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
            return null;

        var newCustomization = new Customization()
        {
            Settings = savedUser.Settings,
            Brand = savedUser.Brand
        };

        return newCustomization;
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
    public async Task<Customization> GetCustomizationAsync()
    {
        var userId = GetClaimValue("userId");

        if (userId is null)
            return null;

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

        if(userId is null)
            return null;

        var user = await GetUserByIdAsync(userId);

        var personalInfo = new PersonalInfoResponse();
        personalInfo.PersonalInfo = user.PersonalInfo;
        personalInfo.ConnectedAccountList = user.ConnectedAccountList;

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

        if (token is not null)
        {
            var claim = token.Claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value;
        }

        return null;
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