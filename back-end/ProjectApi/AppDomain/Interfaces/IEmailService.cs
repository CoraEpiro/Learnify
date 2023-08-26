using AppDomain.Entities.UserRelated;

namespace AppDomain.Interfaces;

/// <summary>
/// Represents an interface for sending and verifying emails with OTP codes.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Asynchronously sends an email containing an OTP code to the specified email address.
    /// </summary>
    /// <param name="email">Recipient's email address.</param>
    /// <param name="otpCode">OTP code to be included in the email.</param>
    /// <returns>Task representing the asynchronous operation.</returns>
    Task SendEmailAsync(string email, string otpCode);

    /// <summary>
    /// Asynchronously verifies an email address by comparing the provided OTP code.
    /// </summary>
    /// <param name="email">Email address to be verified.</param>
    /// <param name="otpCode">OTP code to be checked for verification.</param>
    /// <returns>Task containing the result of the email verification.</returns>
    Task<EmailVerification> VerifyEmailAsync(string email, string otpCode);
}