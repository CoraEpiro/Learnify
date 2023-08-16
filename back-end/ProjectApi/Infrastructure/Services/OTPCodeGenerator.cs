namespace Infrastructure.Services;

public static class OTPCodeGenerator
{
    public static string GenerateOTPCode()
    {
        Random random = new Random();
        int code = random.Next(100000, 999999); // Generates a random number between 100000 and 999999

        return code.ToString("D6"); // Formats the code as a 6-digit string with leading zeros
    }
}