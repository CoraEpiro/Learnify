using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Interfaces;

/// <summary>
/// Interface for a JWT service responsible for generating a security token for a given email address.
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Generates a JWT security token for the given email address and id.
    /// </summary>
    /// <param name="id">The id to generate the token for.</param>
    /// <param name="email">The email address to generate the token for.</param>
    /// <returns>The generated JWT security token.</returns>
    string GenerateSecurityToken(string id, string email);
}