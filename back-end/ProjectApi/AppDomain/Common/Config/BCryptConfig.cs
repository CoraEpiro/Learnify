using System.Diagnostics.Eventing.Reader;
using BCrypt.Net;

namespace AppDomain.Common.Config;

/// <summary>
/// Provides configuration options for BCrypt password hashing.
/// </summary>
public class BCryptConfig
{
    /// <summary>
    /// Gets or sets the work factor used for password hashing. This value determines the time and resources required to hash a password.
    /// </summary>
    public int WorkFactor { get; set; } = 7;

    /// <summary>
    /// Gets or sets the hash algorithm used for password hashing. The default algorithm is Blowfish.
    /// </summary>
    public HashType HashType { get; set; } = HashType.SHA512;

    /// <summary>
    /// Gets or sets a value indicating whether to use enhanced entropy for the random number generator used by BCrypt.
    /// Enhanced entropy collects additional data from user input devices such as the mouse or keyboard to improve randomness.
    /// </summary>
    public bool EnhancedEntropy { get; set; }
}