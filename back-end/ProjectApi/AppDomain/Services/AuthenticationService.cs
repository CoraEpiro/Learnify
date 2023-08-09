using AppDomain.Interfaces;

namespace AppDomain.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly LearnifyDbContext _context;
    private readonly ICryptService _cryptService;

    public AuthenticationService(LearnifyDbContext context, ICryptService cryptService)
    {
        _context = context;
        _cryptService = cryptService;
    }

    public async Task<bool> IsEmailExistAsync(string email) // LogIn və Register - dən əvvəl yoxlamaq üçün çağırılacaq.
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);

        if (user is null)
            return false;

        return true;
    }

    public async Task<bool> IsUsernameExistAsync(string username) // LogIn və Register - dən əvvəl yoxlamaq üçün çağırılacaq.
    {
        var user = _context.Users.FirstOrDefault(x => x.UserName == username);

        if (user is null)
            return false;

        return true;
    }

    public async Task<Task> LogInAsync(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);

        if (user is null)
            return null!;

        var passwordCheck = _cryptService.CheckPassword(password, user.Password!);

        if (passwordCheck)
            return Task.CompletedTask;

        return null!;
    }

    public async Task<Task> RegisterAsync(UserCreateRequest userCreateRequest)
    {
        var emailExist = await IsEmailExistAsync(userCreateRequest.Email);

        if (emailExist)
            return null!;

        var pendingUser = new PendingUser
        {
            Name = userCreateRequest.Name,
            Email = userCreateRequest.Email,
            Password = _cryptService.CryptPassword(userCreateRequest.Password),
            UserSecret = userCreateRequest.UserSecret,
            CreatedTime = DateTime.Now,
        };

        await _context.PendingUsers.AddAsync(pendingUser);
        await _context.SaveChangesAsync();

        return null!;
    }
}