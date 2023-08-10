using AppDomain.DTOs.User;
using Application.DTOs.User;

namespace AppDomain.Interfaces;
public interface IUserRepository
{
    Task<UserDTO> GetUserByIdAsync(string? id);
    Task<UserDTO> GetUserByEmailAsync(string? email);
    Task<UserDTO> GetUserByUsersecretAsync(string? userSecret);
    Task<UserDTO> GetUserByUsernameAsync(string? userName);
}