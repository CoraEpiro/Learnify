using AppDomain.DTOs.User;
using Application.Tasks.Commands.Delete.UserDeletes.VerifyEmail;
using Application.Tasks.Commands.Insert.UserInserts.InserOTPCode;
using Application.Tasks.Commands.Insert.UserInserts.InsertUser;
using Application.Tasks.Commands.Update.UpdateUser.UpdateToken;
using Application.Tasks.Queries.UserQueries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller responsible for user authorization operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizationController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator for handling requests and notifications.</param>
    public AuthorizationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Registers a new user and returns a token upon successful registration.
    /// </summary>
    [HttpPost("RegisterUser")]
    public async Task<ActionResult<string>> RegisterUser([FromBody] InsertUserCommand insertCommand)
    {
        var token = await _mediator.Send(insertCommand);

        if (token is null)
            return BadRequest();

        return Ok(token);
    }

    /// <summary>
    /// Logs in a user and returns a token upon successful authentication.
    /// </summary>
    [HttpPost("LogInUser")]
    public async Task<ActionResult<TokenID>> LogInUser([FromBody] GetUserQuery loginCommand)
    {
        var tokenID = await _mediator.Send(loginCommand);

        if (tokenID is null)
            return BadRequest();

        return Ok(tokenID);
    }

    /// <summary>
    /// Refreshes the authentication token and returns the updated token.
    /// </summary>
    [HttpPost("RefreshToken")]
    public async Task<ActionResult<string>> RefreshToken(UpdateTokenCommand updateTokenCommand)
    {
        var token = await _mediator.Send(updateTokenCommand);

        if (token is null)
            return BadRequest();

        return Ok(token);
    }

    /// <summary>
    /// Sends an OTP code to the user's email for verification.
    /// </summary>
    /// <param name="insertOTPCommand">The command containing data for sending OTP.</param>
    /// <returns>The result of sending the OTP code.</returns>
    [HttpPost("SendOTPCode")]
    public async Task<ActionResult> SendOTPCode([FromBody] InsertOTPCommand insertOTPCommand)
    {
        var result = await _mediator.Send(insertOTPCommand);

        return Ok(result);
    }

    /// <summary>
    /// Verifies the user's email using the provided verification code.
    /// </summary>
    /// <param name="verifyEmailCommand">The command containing the verification code.</param>
    /// <returns>The result of email verification.</returns>
    [HttpPost("VerifyEmail")]
    public async Task<ActionResult> VerifyEmail([FromBody] VerifyEmailCommand verifyEmailCommand)
    {
        var result = await _mediator.Send(verifyEmailCommand);

        return Ok(result);
    }
}
