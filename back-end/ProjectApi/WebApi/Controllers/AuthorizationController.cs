using AppDomain.Common.Entities;
using AppDomain.DTOs.User;
using AppDomain.Exceptions.UserExceptions;
using Application.Tasks.Commands.Delete.UserDeletes.DeleteEmailVerification;
using Application.Tasks.Commands.Insert.UserInserts.InserOTPCode;
using Application.Tasks.Commands.Insert.UserInserts.InsertUser;
using Application.Tasks.Commands.Update.UpdateUser.UpdateToken;
using Application.Tasks.Queries.UserQueries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers;

/// <summary>
/// Controller responsible for user authorization operations.
/// </summary>
[ApiController]
[Route("api/auth")]
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
    /// With auth
    /// </summary>
    /// <returns></returns>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("with-auth")]
    public async Task<ActionResult> TestWithAuth()
    {
        return Ok();
    }

    /// <summary>
    /// With out auth
    /// </summary>
    /// <returns></returns>
    [HttpGet("without-auth")]
    public async Task<ActionResult> TestWithOutAuth()
    {
        return Ok();
    }

    /// <summary>
    /// Registers a new user and returns a <see cref="UserAuthDto"/>.
    /// </summary>
    [HttpPost("register")]
    public async Task<ActionResult<UserAuthDto>> RegisterUser(
        [FromBody] InsertUserCommand insertCommand
    )
    {
        try
        {
            var authDto = await _mediator.Send(insertCommand);
            return Ok(authDto);
        }
        catch (UserExistException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception)
        {
            return Problem("A problem has occurred please try again later");
        }
    }

    /// <summary>
    /// Logs in a user and returns a <see cref="UserAuthDto"/>.
    /// </summary>
    [HttpPost("login")]
    public async Task<ActionResult<TokenID>> LogInUser([FromBody] GetUserQuery loginCommand)
    {
        try
        {
            var authDto = await _mediator.Send(loginCommand);
            return Ok(authDto);
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UserInvalidPasswordException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return Problem("A problem has occurred please try again later");
        }
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
    public async Task<ActionResult> VerifyEmail([FromBody] DeleteEmailVerificationCommand deleteEmailVerificationCommand)
    {
        var result = await _mediator.Send(deleteEmailVerificationCommand);

        if (result is null)
        {
            GeneralResponse response = new() { Result = 0, Message = "Invalid OTP code" };

            return BadRequest(response);
        }
        else
        {
            GeneralResponse reponse = new() { Result = result, Message = $"Verification according to email: {deleteEmailVerificationCommand.Email} is deleted." };

            return Ok(reponse);
        }
    }
}