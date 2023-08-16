using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using Application.DTO;
using System.IdentityModel.Tokens.Jwt;

namespace AppDomain.Interfaces;
public interface IUserRepository
{
    /// <summary>
    /// Registers a new user asynchronously and returns the generated user ID.
    /// </summary>
    Task<string> RegisterUserAsync(InsertPendingUserDTO user);

    /// <summary>
    /// Logs in a user asynchronously and returns the generated token ID.
    /// </summary>
    Task<TokenID> LogInAsync(string email, string password);

    /// <summary>
    /// Retrieves a user by their ID asynchronously.
    /// </summary>
    Task<User> GetUserByIdAsync(string? id);

    /// <summary>
    /// Retrieves a user by their email asynchronously.
    /// </summary>
    Task<User> GetUserByEmailAsync(string? email);

    /// <summary>
    /// Retrieves a user by their user secret asynchronously.
    /// </summary>
    Task<User> GetUserByUsersecretAsync(string? userSecret);

    /// <summary>
    /// Retrieves a user by their username asynchronously.
    /// </summary>
    Task<User> GetUserByUsernameAsync(string? userName);

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

    /// <summary>
    /// Checks if a username exists asynchronously.
    /// </summary>
    Task<bool> IsUsernameExistAsync(string username);

    /// <summary>
    /// Checks if an email exists asynchronously.
    /// </summary>
    Task<bool> IsEmailExistAsync(string email);

    /// <summary>
    /// Retrieves a JWT security token from the request.
    /// </summary>
    JwtSecurityToken GetTokenFromRequest();
}