using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Tasks.Commands.Delete.DeleteUser;
using Application.Tasks.Commands.Insert.InsertUser;
using Infrastructure.Services;
using AppDomain.DTOs.User;
using AppDomain.DTO;
using Application.Tasks.Queries.GetUserById;
using Application.Tasks.Queries.GetPendingUserById;
using Application.Tasks.Queries.GetUserByUsername;
using Application.Tasks.Queries.GetUserByUsersecret;
using Application.Tasks.Commands.Update.UpdateUsername;
using Application.Tasks.Commands.Update.UpdatePassword;
using Application.Tasks.Queries.GetUserByEmail;
using Microsoft.AspNetCore.Authorization;
using Application.Tasks.Queries.GetUser;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    //private readonly LearnifyDbContext _context;
   
    public UserController(IMediator mediator/*, LearnifyDbContext context*/)
    {
        _mediator = mediator;
        //_context = context;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<string>> RegisterUser(InsertUserCommand insertCommand)
    {
        var token = await _mediator.Send(insertCommand);

        return token;
    }

    [HttpGet("LogIn")]
    public async Task<ActionResult<string>> LogInUser([FromQuery]GetUserCommand loginCommand)
    {
        var token = await _mediator.Send(loginCommand);

        return token;
    }

    [HttpPatch("Username")]
    public async Task<UserDTO> UpdateUsername(UpdateUsernameCommand updateCommand)
    {
        var user = await _mediator.Send(updateCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    [HttpPatch("Password")]
    public async Task<UserDTO> UpdatePassword(UpdatePasswordCommand updateCommand)
    {
        var user = await _mediator.Send(updateCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    /*[HttpPatch("Password")]
    public async Task<UserDTO> BuildUser(UpdatePasswordCommand updateCommand)
    {
        var user = await _mediator.Send(updateCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }*/

    [HttpDelete]
    public async Task<ActionResult> DeleteUser(DeleteUserCommand deleteCommand)
    {
        var result = await _mediator.Send(deleteCommand);

        return Ok();
    }

    [HttpGet("PendingUserById")]
    [Authorize]
    public async Task<PendingUserDTO> GetPendingUserById([FromQuery] GetPendingUserByIdCommand getCommand)
    {
        var pendingUser = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToPendingUserDTO(pendingUser);
    }

    [HttpGet("Id")]
    public async Task<UserDTO> GetUserById([FromQuery] GetUserByIdCommand getCommand)
    {
        var user = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    [HttpGet("Email")]
    public async Task<UserDTO> GetUserByEmail([FromQuery] GetUserByEmailCommand getCommand)
    {
        var user = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    [HttpGet("Username")]
    public async Task<UserDTO> GetUserByUsername([FromQuery] GetUserByUsernameCommand getCommand)
    {
        var user = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    [HttpGet("Usersecret")]
    public async Task<UserDTO> GetUserByUsersecret([FromQuery] GetUserByUsersecretCommand getCommand)
    {
        var user = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }
}