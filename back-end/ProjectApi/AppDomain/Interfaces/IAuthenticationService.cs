namespace AppDomain.Interfaces;
public interface IAuthenticationService
{
    Task<Task> LogInAsync(string email, string password);
    Task<Task> RegisterAsync(UserCreateRequest userRequest);
    Task<bool> IsUsernameExistAsync(string username);
    Task<bool> IsEmailExistAsync(string email);
}