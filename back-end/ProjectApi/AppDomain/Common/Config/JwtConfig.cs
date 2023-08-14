namespace AppDomain.Common.Config;

/// <summary>
/// Represents the configuration for JWT tokens.
/// </summary>
public class JwtConfig
{
    /// <summary>
    /// Gets or sets the secret used to sign and verify JWT tokens.
    /// </summary>
    public string Secret { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the issuer of the JWT tokens.
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the audience of the JWT tokens.
    /// </summary>
    public string Audience { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the number of days after which a JWT token will expire.
    /// </summary>
    public int ExpiresInMinutes { get; set; }
}