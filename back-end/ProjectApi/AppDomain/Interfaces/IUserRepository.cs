using AppDomain.Exceptions.UserExceptions;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using Application.DTO;
using AppDomain.Responses;
using AppDomain.ValueObjects;

namespace AppDomain.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Registers a new user asynchronously and returns the generated user ID.
    /// </summary>
    /// <exception cref="UserExistException"/>
    Task<UserAuthDto> RegisterUserAsync(InsertPendingUserDTO user);

    /// <summary>
    /// Logs in a user asynchronously and returns the generated token ID.
    /// </summary>
    /// <exception cref="UserNotFoundException"/>
    /// <exception cref="UserInvalidPasswordException"/>
    Task<UserAuthDto> LogInAsync(string email, string password);

    /// <summary>
    /// Retrieves a user by their ID asynchronously.
    /// </summary>
    Task<User> GetUserByIdAsync(string? id);

    /// <summary>
    /// Retrieves a user by their email asynchronously.
    /// </summary>
    Task<User> GetUserByEmailAsync(string? email);

    /// <summary>
    /// Retrieves a user by their username asynchronously.
    /// </summary>
    Task<User> GetUserByUsernameAsync(string? userName);

    /// <summary>
    /// Retrieves a user by their user secret asynchronously.
    /// </summary>
    Task<User> GetUserByUserSecretAsync(string? userSecret);

    /// <summary>
    /// Retrieves the user's profile asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The user's profile information.</returns>
    Task<UserProfile> GetUserProfileAsync();

    /// <summary>
    /// Retrieves customization information asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The customization information.</returns>
    Task<Customization> GetCustomizationAsync();

    /// <summary>
    /// Retrieves personal information asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. Personal information response.</returns>
    Task<PersonalInfoResponse> GetPersonalInfoAsync();

    /// <summary>
    /// Retrieves the published counts associated with a user asynchronously.
    /// </summary>
    /// <param name="userId">The user's ID.</param>
    /// <returns>A task representing the asynchronous operation. The published counts for the user.</returns>
    Task<UserResponsePublishedCounts> GetUserResponsePublishedCountsAsync(string userId);

    /// <summary>
    /// Updates the username of a user asynchronously and returns the updated user.
    /// </summary>
    Task<User> UpdateUsernameAsync(string id, string newUsername);

    /// <summary>
    /// Updates the password of a user asynchronously and returns the updated user.
    /// </summary>
    Task<User> UpdatePasswordAsync(string newPassword);

    /// <summary>
    /// Initiates the password renewal process asynchronously.
    /// </summary>
    /// <param name="email">The email address of the user requesting password renewal.</param>
    /// <param name="newPassword">The new password to be set.</param>
    /// <returns>A nested task representing the asynchronous operation of renewing the password.</returns>
    Task<Task> RenewPasswordAsync(string email, string newPassword);

    /// <summary>
    /// Updates personal information asynchronously.
    /// </summary>
    /// <param name="response">The updated personal information response.</param>
    /// <returns>A task representing the asynchronous operation. The updated personal information response.</returns>
    Task<PersonalInfoResponse> UpdatePersonalInfoAsync(PersonalInfoResponse response);

    /// <summary>
    /// Updates the user's authentication token asynchronously.
    /// </summary>
    Task<string> UpdateTokenAsync();

    /// <summary>
    /// Updates the user's profile asynchronously.
    /// </summary>
    /// <param name="profile">The updated user profile information.</param>
    /// <returns>A task representing the asynchronous operation. The updated user profile information.</returns>
    Task<UserProfile> UpdateProfileAsync(UserProfile profile);

    /// <summary>
    /// Updates customization information asynchronously.
    /// </summary>
    /// <param name="customization">The updated customization information.</param>
    /// <returns>A task representing the asynchronous operation. The updated customization information.</returns>
    Task<Customization> UpdateCustomizationAsync(Customization customization);

    /// <summary>
    /// Builds and returns a user object asynchronously based on provided information.
    /// </summary>
    Task<User> BuildUserAsync(BuildUserDTO buildUser);

    /// <summary>
    /// Deletes a user asynchronously and returns a task.
    /// </summary>
    Task<User> DeleteUserAsync(string id);

    /// <summary>
    /// Deletes an email verification record asynchronously.
    /// </summary>
    /// <param name="email">The email address associated with the verification.</param>
    /// <param name="otpCode">The one-time password code used for verification.</param>
    /// <returns>A task representing the asynchronous operation. A string indicating the result of the deletion.</returns>
    Task<string> DeleteEmailVerificationAsync(string email, string otpCode);

    /// <summary>
    /// Checks if a username exists asynchronously.
    /// </summary>
    Task<bool> IsUsernameExistAsync(string username);

    /// <summary>
    /// Sends an OTP code to the user's email for verification.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>A task representing the asynchronous operation to send the OTP code.</returns>
    Task<Task> SendOTPCodeAsync(string email);

    /// <summary>
    /// Checks if an email exists asynchronously.
    /// </summary>
    Task<bool> IsEmailExistAsync(string email);
}