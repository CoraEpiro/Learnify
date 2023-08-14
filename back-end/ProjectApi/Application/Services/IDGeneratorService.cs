namespace Application.Services;

/// <summary>
/// Service for generating unique identifiers.
/// </summary>
public static class IDGeneratorService
{
    /// <summary>
    /// Generates a new unique identifier.
    /// </summary>
    /// <returns>A string representing the new unique identifier.</returns>
    public static string GetUniqueId() => Guid.NewGuid().ToString("N").ToLower();

    /// <summary>
    /// Generates a news short (length 8) unique identifier.
    /// </summary>
    /// <returns>A string representing the new unique identifier.</returns>
    public static string GetShortUniqueId() => Guid.NewGuid().ToString("N").ToLower()[..8];
}