using Application.DTOs.User;

namespace AppDomain.Interfaces;
public interface IUserService
{
    Task<UserResponse> GetUserByIdAsync(string? id);
    Task<UserResponse> GetUserByEmailAsync(string? email);
    Task<UserResponse> GetUserByUsersecretAsync(string? userSecret);
    Task<UserResponse> GetUserByUsernameAsync(string? userName);
}