using AppDomain.Interfaces;
using Application.DTOs.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    // GET api/<AuthenticationController>/5
    [HttpGet("{email, password}")]
    public async Task<Task> LogInUser(string email, string password)
    {
        var check = await _authenticationService.LogInAsync(email, password);

        return check;
    }

    // POST api/<AuthenticationController>
    [HttpPost]
    public async Task<Task> RegisterUser([FromBody] UserCreateRequest userCreateReuqest)
    {
        var check = await _authenticationService.RegisterAsync(userCreateReuqest);

        return check;
    }
}