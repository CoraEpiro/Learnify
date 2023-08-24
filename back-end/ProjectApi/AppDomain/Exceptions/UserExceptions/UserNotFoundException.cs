namespace AppDomain.Exceptions.UserExceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string userSelector)
        : base($"User not found for - {userSelector}") { }
}
