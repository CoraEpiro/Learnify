namespace AppDomain.Exceptions.UserExceptions;

public class UserExistException : Exception
{
    public UserExistException(string userSelector)
        : base($"User already exist for - {userSelector}") { }
}
