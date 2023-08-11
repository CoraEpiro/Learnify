using AppDomain.Common.Config;
using AppDomain.Interfaces;

namespace Infrastructure.Services;

/// <inheritdoc/>
public class CryptService : ICryptService
{
    private readonly BCryptConfig _config;

    /// <summary>
    /// Initialize object
    /// </summary>
    /// <param name="config"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CryptService(BCryptConfig config) =>
        _config = config;

    /// <inheritdoc/>
    public bool CheckPassword(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.Verify(
            password,
            hashedPassword,
            _config.EnhancedEntropy,
            _config.HashType
        );

    /// <inheritdoc/>
    public string CryptPassword(string password) =>
        BCrypt.Net.BCrypt.HashPassword(
            password,
            GenerateSalt(),
            _config.EnhancedEntropy,
            _config.HashType
        );

    /// <inheritdoc/>
    public string GenerateSalt() => BCrypt.Net.BCrypt.GenerateSalt(_config.WorkFactor);
}