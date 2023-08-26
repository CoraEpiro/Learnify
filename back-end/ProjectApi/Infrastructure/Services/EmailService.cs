using AppDomain.Interfaces;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using AppDomain.Entities.UserRelated;

namespace Infrastructure.Services;


/// <inheritdoc/>
public class EmailService : IEmailService
{
    private readonly LearnifyDbContext _context;

    public EmailService(LearnifyDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task SendEmailAsync(string email, string otpCode)
    {
        var htmlTemplate = @"<!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""UTF-8"" />
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                <title>Document</title>
            </head>
            <style>
                *,
                html,
                body {
                    margin: 0;
                    padding: 0;
                    box-sizing: border-box;
                    font-family: ""Roboto"", sans-serif;
                }

                .container {
                    height: 80vh;
                    width: 100%;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    background: #cecece;
                }

                .container .box_container {
                    background: white;
                    width: 60%;
                    border-radius: 1rem;
                    padding-inline: 2rem;
                    padding-block: 2rem;
                }

                .container .box_container h1 {
                    text-align: center;
                    margin-bottom: 1.4rem;
                    color: #3b49df;
                }

                .container .box_container h2 {
                    text-align: center;
                }

                .container .box_container h2 b {
                    color: #3b49df;
                }

                .container .box_container p {
                    padding-block: 0.6rem;
                    font-size: 1.1rem;
                    line-height: 1.5em;
                    color: #444;
                    text-align: center;
                }

                .container .box_container p b {
                    color: #3b49df;
                }

                .container .box_container .otp {
                    margin-block: 2rem;
                    background: #efefef;
                    width: -webkit-fit-content;
                    width: -moz-fit-content;
                    width: fit-content;
                    margin-inline: auto;
                    padding-inline: 4rem;
                    padding-block: 0.8rem;
                    border-radius: 0.2rem;
                    display: flex;
                    align-items: center;
                    justify-content: center;
                }

                .container .box_container .otp h1 {
                    margin: 0;
                }

                .container .box_container .disclaimer {
                    width: 100%;
                    text-align: center;
                    margin-bottom: 2rem;
                }

                .container .box_container .disclaimer small {
                    color: #4f4f4f;
                }

                .container .box_container footer {
                    text-align: center;
                    margin-top: 1rem;
                }

                .container .box_container footer section:nth-child(2) {
                    margin-top: 1rem;
                    font-weight: 600;
                }
            </style>
            <body>
                <div class=""container"">
                    <div class=""box_container"">
                        <h1>Learnify</h1>
                        <h2>Verify Email</h2>
                        <p>
                            Thank you for choosing <b>Learnify</b>. Use the following OTP to
                            complete your procedures. OTP is valid for 2 minutes
                        </p>
                        <div class=""otp"">
                            <h1>" + otpCode + @"</h1>
                        </div>
                        <div class=""disclaimer"">
                            <small>
                                Please do not share this otp with anyone. If not requested by you
                                please ignore this email.
                            </small>
                        </div>
                        <footer>
                            <section>Made with ❤️ by Learrnify</section>
                            <section>Copyright of LEARNIFY &copy; 2023</section>
                        </footer>
                    </div>
                </div>
            </body>
            </html>";

        string fromMail = "LearnifyProject@gmail.com";
        string password = "uepfoaaavaqmefkf";

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(fromMail);
        mailMessage.Subject = "Your OTP Code";
        mailMessage.To.Add(email);
        //mailMessage.Body = $"Your OTP code is: {otpCode}";
        mailMessage.Body = htmlTemplate;
        mailMessage.IsBodyHtml = true;


        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, password),
            EnableSsl = true
        };

        smtpClient.Send(mailMessage);
    }

    /// <inheritdoc/>
    public async Task<EmailVerification> VerifyEmailAsync(string email, string otpCode)
    {
        var verification = await _context.EmailVerifications.FirstOrDefaultAsync(
            x => x.Email == email && x.OTP == otpCode);

        if (verification is null)
            return null;

        else if (verification.ExpireUntil < DateTime.UtcNow)
            return null;

        return verification;
    }
}