using AppDomain.DTO;
using AppDomain.DTOs.User;
using AppDomain.Entities.UserRelated;
using Application.DTO;

namespace AppDomain.Interfaces;
public interface IUserRepository
{
    Task<string> RegisterUserAsync(InsertPendingUserDTO user);
    Task<string> LogInAsync(string email, string password);
    Task<PendingUser> GetPendingUserByIdAsync(string? id);
    Task<User> GetUserByIdAsync(string? id);
    Task<User> GetUserByEmailAsync(string? email);
    Task<User> GetUserByUsersecretAsync(string? userSecret);
    Task<User> GetUserByUsernameAsync(string? userName);
    Task<User> UpdateUsernameAsync(string id, string newUsername);
    Task<User> UpdatePasswordAsync(string id, string newPassword);
    Task<User> BuildUserAsync(BuildUserDTO buildUser);
    Task<Task> DeleteUserAsync(string id);
    Task<bool> IsUsernameExistAsync(string username);
    Task<bool> IsEmailExistAsync(string email);
}