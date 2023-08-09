using AppDomain.Interfaces;

namespace AppDomain.Services;
public class UserService : IUserService
{
    private readonly LearnifyDbContext _context;

    public UserService(LearnifyDbContext context)
    {
        _context = context;
    }

    public Task<UserResponse> GetUserByEmailAsync(string? email)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);
        
        var userResponse = DtoAndModelConvertors.ToUserResponse(user!);

        return Task.FromResult(userResponse);
    }

    public Task<UserResponse> GetUserByUsernameAsync(string? userName)
    {
        var user = _context.Users.FirstOrDefault(x => x.UserName == userName);

        var userResponse = DtoAndModelConvertors.ToUserResponse(user!);

        return Task.FromResult(userResponse);
    }

    public Task<UserResponse> GetUserByUsersecretAsync(string? userSecret)
    {
        var user = _context.Users.FirstOrDefault(x => x.UserSecret == userSecret);

        var userResponse = DtoAndModelConvertors.ToUserResponse(user!);

        return Task.FromResult(userResponse);
    }

    public Task<UserResponse> GetUserByIdAsync(string? id)
    {
        var user = _context.Users.Find(id);

        var userResponse = DtoAndModelConvertors.ToUserResponse(user!);

        return Task.FromResult(userResponse);
    }
}