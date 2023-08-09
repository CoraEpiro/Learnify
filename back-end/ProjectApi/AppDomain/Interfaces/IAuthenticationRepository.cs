using AppDomain.DTOs.User;

namespace AppDomain.Interfaces;
public interface IAuthenticationRepository
{
    Task<Task> LogInAsync(string email, string password);
    Task<Task> RegisterAsync(UserDTO userDTO);
    Task<bool> IsUsernameExistAsync(string username);
    Task<bool> IsEmailExistAsync(string email);
}