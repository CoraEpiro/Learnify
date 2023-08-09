using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppDomain.Interfaces;
using AppDomain.Entities.UserRelated;
using Application.DTOs.User;
using MediatR;
using Application.Tasks.Commands.Insert.InsertUser;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
   
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    [HttpPost]
    public async Task<ActionResult> PostUser(InsertUserCommand insertCommand)
    {
        var result = _mediator.Send(insertCommand);

        return Ok(result);
    }

    
}