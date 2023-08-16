using AppDomain.DTOs.User;
using Application.Tasks.Commands.Insert.UserInserts.InsertUser;
using Application.Tasks.Commands.Update.UpdateUser.UpdatePassword;
using Application.Tasks.Commands.Update.UpdateUser.UpdateToken;
using Application.Tasks.Queries.UserQueries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorizationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("RegisterUser")]
    public async Task<ActionResult<string>> RegisterUser([FromBody] InsertUserCommand insertCommand)
    {
        var token = await _mediator.Send(insertCommand);

        if (token is null)
            return BadRequest();

        return Ok(token);
    }

    [Authorize]
    [HttpPost("LogInUser")]
    public async Task<ActionResult<TokenID>> LogInUser([FromBody] GetUserQuery loginCommand)
    {
        var tokenID = await _mediator.Send(loginCommand);

        if (tokenID is null)
            return BadRequest();

        return Ok(tokenID);
    }

    [HttpPost("RefreshToken")]
    public async Task<ActionResult<string>> RefreshToken(UpdateTokenCommand updateTokenCommand)
    {
        var token = await _mediator.Send(updateTokenCommand);

        if (token is null)
            return BadRequest();

        return Ok(token);
    }
}