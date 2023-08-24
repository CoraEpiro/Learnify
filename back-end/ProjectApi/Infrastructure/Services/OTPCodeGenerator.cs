namespace Infrastructure.Services;

/// <summary>
/// Service for Generating OTP codes.
/// </summary>
public static class OTPCodeGenerator
{
    /// <summary>
    /// Generate Otp code.
    /// </summary>
    /// <returns></returns>
    public static string GenerateOTPCode()
    {
        Random random = new();
        int code = random.Next(100000, 999999); // Generates a random number between 100000 and 999999

        return code.ToString("D6"); // Formats the code as a 6-digit string with leading zeros
    }
}
