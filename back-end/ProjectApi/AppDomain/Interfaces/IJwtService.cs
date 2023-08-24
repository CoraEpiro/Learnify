using AppDomain.Enums;
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
    /// Generates a JWT security token for a user with the specified ID and email.
    /// </summary>
    /// <param name="id">The user's ID.</param>
    /// <param name="email">The user's email address.</param>
    /// <param name="role">The user's  role.</param>
    /// <returns>The JWT security token as a string.</returns>
    string GenerateSecurityToken(string id, string email, UserRole role);
}
