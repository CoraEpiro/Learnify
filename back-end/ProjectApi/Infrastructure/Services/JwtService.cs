using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AppDomain.Common.Config;
using AppDomain.Enums;
using AppDomain.Interfaces;
using Microsoft.IdentityModel.Tokens;

/// <inheritdoc/>
public class JwtService : IJwtService
{
    private readonly JwtConfig _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtService"/> class.
    /// </summary>
    /// <param name="config">The JWT configuration settings.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="config"/> is null.</exception>
    public JwtService(JwtConfig config) =>
        _config = config ?? throw new ArgumentNullException(nameof(config));

    /// <inheritdoc/>
    public string GenerateSecurityToken(string id, string email, UserRole role)
    {
        var claims = new[]
        {
            new Claim("userId", id),
            new Claim("userEmail", email),
            new Claim("userRole", role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Audience,
            expires: DateTime.UtcNow.AddMinutes(_config.ExpiresInMinutes),
            signingCredentials: signingCredentials,
            claims: claims
        );
        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        return accessToken;
    }
}
