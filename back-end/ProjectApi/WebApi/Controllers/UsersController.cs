using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Tasks.Commands.Delete.DeleteUser;
using Application.Tasks.Commands.Insert.InsertUser;
using AppDomain.DTO;
using Application.Tasks.Commands.Update.UpdateUser.BuildUser;
using Application.Tasks.Commands.Update.UpdateUser.UpdatePassword;
using Application.Tasks.Commands.Update.UpdateUser.UpdateUsername;
using Application.Tasks.Queries.UserQueries.GetUserByUsersecret;
using Application.Tasks.Queries.UserQueries.GetUserByUsername;
using Application.Tasks.Queries.UserQueries.GetUserById;
using Application.Tasks.Queries.UserQueries.GetUserByEmail;
using Application.Tasks.Queries.UserQueries.GetUser;

namespace WebApi.Controllers;

/// <summary>
/// Controller for managing user-related operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator used for handling commands and queries.</param>
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Updates the username of a user.
    /// </summary>
    /// <param name="updateCommand">The command containing update information.</param>
    /// <returns>The updated user's DTO if successful, NotFound if user not found.</returns>
    [HttpPatch("UpdateUsername/{Id}/{Username}")]
    public async Task<ActionResult<UserDTO>> UpdateUsername(UpdateUsernameCommand updateCommand)
    {
        var user = await _mediator.Send(updateCommand);

        if (user is null)
            return NotFound();

        var userDTO = DtoAndModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Updates the password of a user.
    /// </summary>
    /// <param name="updateCommand">The command containing update information.</param>
    /// <returns>The updated user's DTO if successful, NotFound if user not found.</returns>
    [HttpPatch("UpdatePassword/{Id}/{Password}")]
    public async Task<ActionResult<UserDTO>> UpdatePassword(UpdatePasswordCommand updateCommand)
    {
        var user = await _mediator.Send(updateCommand);

        if (user is null)
            return NotFound();

        var userDTO = DtoAndModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Builds a new user.
    /// </summary>
    /// <param name="buildCommand">The command containing user information.</param>
    /// <returns>The created user's DTO if successful, NotFound if user creation fails.</returns>
    [HttpPost("BuildUser")]
    public async Task<ActionResult<UserDTO>> BuildUser([FromBody] BuildUserCommand buildCommand)
    {
        var user = await _mediator.Send(buildCommand);

        if (user is null)
            return NotFound();

        var userDTO = DtoAndModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="deleteCommand">The command containing user deletion information.</param>
    /// <returns>Ok if deletion is successful.</returns>
    [HttpDelete("DeleteUser/{Id}")]
    public async Task<ActionResult> DeleteUser(DeleteUserCommand deleteCommand)
    {
        await _mediator.Send(deleteCommand);

        return Ok();
    }

    /// <summary>
    /// Retrieves a user by their ID.
    /// </summary>
    /// <param name="getCommand">The query containing user ID.</param>
    /// <returns>The retrieved user's DTO if found, NotFound if user not found.</returns>
    [HttpGet("GetUserById/{Id}")]
    public async Task<ActionResult<UserDTO>> GetUserById(GetUserByIdQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userDTO = DtoAndModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="getCommand">The query containing email address.</param>
    /// <returns>The retrieved user's DTO if found, NotFound if user not found.</returns>
    [HttpGet("GetUserByEmail/{Email}")]
    public async Task<ActionResult<UserDTO>> GetUserByEmail(GetUserByEmailQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userDTO = DtoAndModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="getCommand">The query containing username.</param>
    /// <returns>The retrieved user's DTO if found, NotFound if user not found.</returns>
    [HttpGet("GetUserByUsername/{Username}")]
    public async Task<ActionResult<UserDTO>> GetUserByUsername(GetUserByUsernameQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userDTO = DtoAndModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Retrieves a user by their secret.
    /// </summary>
    /// <param name="getCommand">The query containing user secret.</param>
    /// <returns>The retrieved user's DTO if found, NotFound if user not found.</returns>
    [HttpGet("GetUserByUsersecret/{Secret}")]
    public async Task<ActionResult<UserDTO>> GetUserByUsersecret(GetUserByUsersecretQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userDTO = DtoAndModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }
}
