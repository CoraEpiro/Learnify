using Microsoft.AspNetCore.Mvc;
using MediatR;
using AppDomain.DTO;
using Application.Tasks.Commands.Update.UpdateUser.UpdatePassword;
using Application.Tasks.Commands.Update.UpdateUser.UpdateUsername;
using Application.Tasks.Queries.UserQueries.GetUserByUsersecret;
using Application.Tasks.Queries.UserQueries.GetUserByUsername;
using Application.Tasks.Queries.UserQueries.GetUserById;
using Application.Tasks.Queries.UserQueries.GetUserByEmail;
using Application.Tasks.Commands.Insert.UserInserts.BuildUser;
using Application.Tasks.Commands.Delete.UserDeletes.DeleteUser;
using Application.Tasks.Queries.UserQueries.UserExistByEmail;
using Application.Tasks.Queries.UserQueries.UserExistByUsername;
using AppDomain.Responses;
using AppDomain.Interfaces;
using Application.Tasks.Commands.Update.UpdateUser.UpdateProfile;
using Application.Tasks.Commands.Update.UpdateUser.UpdatePersonalInfo;
using Application.Tasks.Commands.Update.UpdateUser.UpdateCustomization;

namespace WebApi.Controllers;

/// <summary>
/// Controller for managing user-related operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of the UsersController class with the required dependencies.
    /// </summary>
    /// <param name="mediator">The mediator for handling requests and commands.</param>
    /// <param name="userRepository">The repository for user-related operations.</param>
    public UsersController(IMediator mediator, IUserRepository userRepository)
    {
        _mediator = mediator;
        _userRepository = userRepository;
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

        var userDTO = ModelConvertors.ToUserDTO(user);

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

        var userDTO = ModelConvertors.ToUserDTO(user);

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

        var userDTO = ModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Retrieves a user by their secret.
    /// </summary>
    /// <param name="getCommand">The query containing user secret.</param>
    /// <returns>The retrieved user's DTO if found, NotFound if user not found.</returns>
    [HttpGet("GetUserByUserSecret/{Secret}")]
    public async Task<ActionResult<UserDTO>> GetUserByUserSecret(GetUserByUsersecretQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userDTO = ModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Retrieves detailed user information in the form of a UserResponse based on their ID.
    /// </summary>
    /// <param name="getCommand">The query containing the user's ID.</param>
    /// <returns>The retrieved user's detailed information if found, NotFound if user not found.</returns>
    [HttpGet("GetUserResponseById/{Id}")]
    public async Task<ActionResult<UserResponse>> GetUserResponseById(GetUserByIdQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var counts = await _userRepository.GetUserResponsePublishedCountsAsync(user.Id);

        var userResponse = ModelConvertors.ToUserResponse(user, counts);

        return Ok(userResponse);
    }

    /// <summary>
    /// Retrieves detailed user information in the form of a UserResponse based on their email.
    /// </summary>
    /// <param name="getCommand">The query containing the user's email.</param>
    /// <returns>The retrieved user's detailed information if found, NotFound if user not found.</returns>
    [HttpGet("GetUserResponseByEmail/{Email}")]
    public async Task<ActionResult<UserResponse>> GetUserResponseByEmail(GetUserByEmailQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var counts = await _userRepository.GetUserResponsePublishedCountsAsync(user.Id);

        var userResponse = ModelConvertors.ToUserResponse(user, counts);

        return Ok(userResponse);
    }

    /// <summary>
    /// Retrieves detailed user information in the form of a UserResponse based on their username.
    /// </summary>
    /// <param name="getCommand">The query containing the user's username.</param>
    /// <returns>The retrieved user's detailed information if found, NotFound if user not found.</returns>
    [HttpGet("GetUserResponseByUsername/{Username}")]
    public async Task<ActionResult<UserResponse>> GetUserResponseByUsername(GetUserByUsernameQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var counts = await _userRepository.GetUserResponsePublishedCountsAsync(user.Id);

        var userResponse = ModelConvertors.ToUserResponse(user, counts);

        return Ok(userResponse);
    }

    /// <summary>
    /// Retrieves detailed user information in the form of a UserResponse based on their user secret.
    /// </summary>
    /// <param name="getCommand">The query containing the user's secret.</param>
    /// <returns>The retrieved user's detailed information if found, NotFound if user not found.</returns>
    [HttpGet("GetUserResponseByUsersecret/{Secret}")]
    public async Task<ActionResult<UserResponse>> GetUserResponseByUsersecret(GetUserByUsersecretQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var counts = await _userRepository.GetUserResponsePublishedCountsAsync(user.Id);

        var userResponse = ModelConvertors.ToUserResponse(user, counts);

        return Ok(userResponse);
    }

    /// <summary>
    /// Retrieves a preview of user information in the form of a UserPreviewResponse based on their ID.
    /// </summary>
    /// <param name="getCommand">The query containing the user's ID.</param>
    /// <returns>The retrieved user's preview information if found, NotFound if user not found.</returns>
    [HttpGet("GetUserPreviewResponseById/{Id}")]
    public async Task<ActionResult<UserPreviewResponse>> GetUserPreviewResponseById(GetUserByIdQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userPreviewResponse = ModelConvertors.ToUserPreviewResponse(user);

        return Ok(userPreviewResponse);
    }

    /// <summary>
    /// Retrieves a preview of user information in the form of a UserPreviewResponse based on their email.
    /// </summary>
    /// <param name="getCommand">The query containing the user's email.</param>
    /// <returns>The retrieved user's preview information if found, NotFound if user not found.</returns>
    [HttpGet("GetUserPreviewResponseByEmail/{Email}")]
    public async Task<ActionResult<UserPreviewResponse>> GetUserPreviewResponseByEmail(GetUserByEmailQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userPreviewResponse = ModelConvertors.ToUserPreviewResponse(user);

        return Ok(userPreviewResponse);
    }

    /// <summary>
    /// Retrieves a preview of user information in the form of a UserPreviewResponse based on their username.
    /// </summary>
    /// <param name="getCommand">The query containing the user's username.</param>
    /// <returns>The retrieved user's preview information if found, NotFound if user not found.</returns>
    [HttpGet("GetUserPreviewResponseByUsername/{Username}")]
    public async Task<ActionResult<UserPreviewResponse>> GetUserPreviewResponseByUsername(GetUserByUsernameQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userPreviewResponse = ModelConvertors.ToUserPreviewResponse(user);

        return Ok(userPreviewResponse);
    }

    /// <summary>
    /// Retrieves a preview of user information in the form of a UserPreviewResponse based on their user secret.
    /// </summary>
    /// <param name="getCommand">The query containing the user's secret.</param>
    /// <returns>The retrieved user's preview information if found, NotFound if user not found.</returns>
    [HttpGet("GetUserPreviewResponseByUsersecret/{Secret}")]
    public async Task<ActionResult<UserPreviewResponse>> GetUserPreviewResponseByUsersecret(GetUserByUsersecretQuery getCommand)
    {
        var user = await _mediator.Send(getCommand);

        if (user is null)
            return NotFound();

        var userPreviewResponse = ModelConvertors.ToUserPreviewResponse(user);

        return Ok(userPreviewResponse);
    }

    /// <summary>
    /// Retrieves the user's profile information.
    /// </summary>
    /// <returns>The user's profile information if available, Problem response if no user profile exists.</returns>
    [HttpGet("GetUserProfile")]
    public async Task<ActionResult<UserProfile>> GetUserProfile()
    {
        var profile = await _userRepository.GetUserProfileAsync();

        if (profile is null)
            return Problem("There is no current user.");

        return Ok(profile);
    }

    /// <summary>
    /// Retrieves customization information asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. Customization information if available, Problem response if not found.</returns>
    [HttpGet("GetCustomization")]
    public async Task<ActionResult<Customization>> GetCustomization()
    {
        var customization = await _userRepository.GetCustomizationAsync();

        if (customization is null)
            return Problem("There is no current user.");

        return Ok(customization);
    }

    [HttpGet("GetPersonalInfo")]
    public async Task<ActionResult<PersonalInfoResponse>> GetPersonalInfo()
    {
        var personalInfo = await _userRepository.GetPersonalInfoAsync();

        if(personalInfo is null)
            return Problem("There is no current user.");

        return Ok(personalInfo);
    }

    /// <summary>
    /// Updates the password of a user.
    /// </summary>
    /// <param name="updateCommand">The command containing update information.</param>
    /// <returns>The updated user's DTO if successful, NotFound if user not found.</returns>
    [HttpPatch("UpdatePassword/{Id}/{Password}")]
    public async Task<ActionResult<UserDTO>> UpdatePassword([FromBody] UpdatePasswordCommand updateCommand)
    {
        var user = await _mediator.Send(updateCommand);

        if (user is null)
            return NotFound();

        var userDTO = ModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
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

        var userDTO = ModelConvertors.ToUserDTO(user);

        return Ok(userDTO);
    }

    /// <summary>
    /// Updates the user's profile information asynchronously.
    /// </summary>
    /// <param name="updateCommand">The command containing updated profile information.</param>
    /// <returns>A task representing the asynchronous operation. The updated user profile if successful, BadRequest if update fails.</returns>
    [HttpPatch("UpdateProfile")]
    public async Task<ActionResult<UserProfile>> UpdateProfile([FromBody] UpdateUserProfileCommand updateCommand)
    {
        var profile = await _mediator.Send(updateCommand);

        if (profile is null)
            return Problem("Update process went wrong.");

        return Ok(profile);
    }

    /// <summary>
    /// Updates the user's personal information asynchronously.
    /// </summary>
    /// <param name="updateCommand">The command containing updated personal information.</param>
    /// <returns>A task representing the asynchronous operation. The updated personal information if successful, BadRequest if update fails.</returns>
    [HttpPatch("UpdatePersonalInfo")]
    public async Task<ActionResult<PersonalInfoResponse>> UpdatePersonalInfo([FromBody] UpdatePersonalInfoCommand updateCommand)
    {
        var personalInfo = await _mediator.Send(updateCommand);

        if (personalInfo is null)
            return Problem("Update process went wrong.");

        return Ok(personalInfo);
    }

    /// <summary>
    /// Updates customization information asynchronously.
    /// </summary>
    /// <param name="updateCommand">The command containing the updated customization information.</param>
    /// <returns>A task representing the asynchronous operation. The updated customization information if successful, BadRequest if the update fails.</returns>
    [HttpPatch("UpdateCustomization")]
    public async Task<ActionResult<Customization>> UpdateCustomization([FromBody] UpdateCustomizationCommand updateCommand)
    {
        var customization = await _mediator.Send(updateCommand);

        if(customization is null)
            return Problem("Update process went wrong.");

        return Ok(customization);
    }

    /// <summary>
    /// Check for user exist for given email address
    /// </summary>
    /// <returns></returns>
    [HttpGet("UserExistByEmail/{Email}")]
    public async Task<ActionResult> UserExistByEmail(UserExistByEmailQuery getCommand)
    {
        try
        {
            return await _mediator.Send(getCommand) ? Ok() : NotFound();
        }
        catch (Exception)
        {
            return Problem("A problem has occurred please try again later");
        }
    }

    /// <summary>
    /// Check for user exist for given username
    /// </summary>
    /// <returns></returns>
    [HttpGet("UserExistByUsername/{Username}")]
    public async Task<ActionResult> UserExistByUsername(UserExistByUsernameQuery getCommand)
    {
        try
        {
            return await _mediator.Send(getCommand) ? Ok() : NotFound();
        }
        catch (Exception)
        {
            return Problem("A problem has occurred please try again later");
        }
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

        var userDTO = ModelConvertors.ToUserDTO(user);

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
}