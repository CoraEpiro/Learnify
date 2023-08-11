namespace AppDomain.Interfaces;
public interface ICryptService
{
    /// <summary>
    /// Generates a random salt string to be used for hashing passwords.
    /// </summary>
    /// <remarks>
    /// The salt is generated using the work factor specified in the <see cref="BCryptConfig"/> class.
    /// The higher the work factor, the slower the hashing, and the more secure the password.
    /// </remarks>
    /// <returns>A random salt string.</returns>
    public string GenerateSalt();

    /// <summary>
    /// Encrypts the specified password.
    /// </summary>
    /// <param name="password">The password to be encrypted.</param>
    /// <returns>The encrypted password.</returns>
    public string CryptPassword(string password);

    /// <summary>
    /// Checks whether the specified password matches the encrypted password.
    /// </summary>
    /// <param name="password">The password to be checked.</param>
    /// <param name="hashedPassword">Te hashed password</param>
    /// <returns>True if the password matches the encrypted password, otherwise false.</returns>
    public bool CheckPassword(string password, string hashedPassword);
}