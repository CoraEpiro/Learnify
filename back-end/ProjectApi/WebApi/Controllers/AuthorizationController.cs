using AppDomain.DTOs.User;
using Application.Tasks.Commands.Insert.InsertUser;
using Application.Tasks.Queries.UserQueries.GetUser;
using MediatR;
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

    [HttpGet("LogInUser/{Email}/{Password}")]
    public async Task<ActionResult<TokenID>> LogInUser(GetUserQuery loginCommand)
    {
        var tokenID = await _mediator.Send(loginCommand);

        if (tokenID is null)
            return BadRequest();

        return Ok(tokenID);
    }
}