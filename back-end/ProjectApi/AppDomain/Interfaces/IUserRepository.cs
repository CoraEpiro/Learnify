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

    Task<UserResponsePublishedCounts> GetUserResponsePublishedCountsAsync(string userId);

    /// <summary>
    /// Updates the username of a user asynchronously and returns the updated user.
    /// </summary>
    Task<User> UpdateUsernameAsync(string id, string newUsername);

    /// <summary>
    /// Updates the password of a user asynchronously and returns the updated user.
    /// </summary>
    Task<User> UpdatePasswordAsync(string id, string newPassword);

    /// <summary>
    /// Updates the user's authentication token asynchronously.
    /// </summary>
    Task<string> UpdateTokenAsync();

    /// <summary>
    /// Builds and returns a user object asynchronously based on provided information.
    /// </summary>
    Task<User> BuildUserAsync(BuildUserDTO buildUser);

    /// <summary>
    /// Deletes a user asynchronously and returns a task.
    /// </summary>
    Task<Task> DeleteUserAsync(string id);


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