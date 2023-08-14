using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Tasks.Commands.Delete.DeleteUser;
using Application.Tasks.Commands.Insert.InsertUser;
using Application.Services;
using AppDomain.DTOs.User;
using AppDomain.DTO;
using Microsoft.AspNetCore.Authorization;
using Application.Tasks.Commands.Update.UpdateUser.BuildUser;
using Application.Tasks.Commands.Update.UpdateUser.UpdatePassword;
using Application.Tasks.Commands.Update.UpdateUser.UpdateUsername;
using Application.Tasks.Queries.UserQueries.GetUserByUsersecret;
using Application.Tasks.Queries.UserQueries.GetUserByUsername;
using Application.Tasks.Queries.UserQueries.GetUserById;
using Application.Tasks.Queries.UserQueries.GetUserByEmail;
using Application.Tasks.Queries.UserQueries.GetUser;
using Application.Tasks.Queries.UserQueries.GetPendingUserById;

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
    public async Task<ActionResult<string>> LogInUser([FromQuery]GetUserQuery loginCommand)
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

    [HttpPost("UserBuild")]
    public async Task<UserDTO> BuildUser(BuildUserCommand buildCommand)
    {
        var user = await _mediator.Send(buildCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser(DeleteUserCommand deleteCommand)
    {
        var result = await _mediator.Send(deleteCommand);

        return Ok();
    }

    [HttpGet("PendingUserById")]
    [Authorize]
    public async Task<PendingUserDTO> GetPendingUserById([FromQuery] GetPendingUserByIdQuery getCommand)
    {
        var pendingUser = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToPendingUserDTO(pendingUser);
    }

    [HttpGet("GetUserById/{Id}")]
    public async Task<UserDTO> GetUserById(GetUserByIdQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    [HttpGet("Email")]
    public async Task<UserDTO> GetUserByEmail([FromQuery] GetUserByEmailQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    [HttpGet("Username")]
    public async Task<UserDTO> GetUserByUsername([FromQuery] GetUserByUsernameQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }

    [HttpGet("Usersecret")]
    public async Task<UserDTO> GetUserByUsersecret([FromQuery] GetUserByUsersecretQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        return DtoAndModelConvertors.ToUserDTO(user);
    }
}