namespace AppDomain.Exceptions.UserExceptions;

public class UserInvalidPasswordException : Exception
{
    public UserInvalidPasswordException(string userSelector)
        : base($"Invalid User Password for - {userSelector}") { }
}