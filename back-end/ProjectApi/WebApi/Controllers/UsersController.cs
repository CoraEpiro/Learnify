using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;
using AppDomain.Interfaces;
using AppDomain.Entities.UserRelated;
using Application.DTOs.User;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly LearnifyDbContext _context;
    private readonly IUserService _userService;

    public UsersController(LearnifyDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUserById(string id)
    {
        if (_context.Users is null)
            return NotFound();

        var user = await _userService.GetUserByIdAsync(id);

        if (user is null)
            return NotFound();

        return user;
    }
    
    // GET: api/Users/admin@gmail.com
    [HttpGet("{email}")]
    public async Task<ActionResult<UserResponse>> GetUserByEmail(string email)
    {
        if (_context.Users is null)
            return NotFound();

        var user = await _userService.GetUserByEmailAsync(email);

        if (user is null)
            return NotFound();

        return user;
    }

    // GET: api/Users/admin
    [HttpGet("{username}")]
    public async Task<ActionResult<UserResponse>> GetUserByUsername(string username)
    {
        if (_context.Users is null)
            return NotFound();

        var user = await _userService.GetUserByUsernameAsync(username);

        if (user is null)
            return NotFound();

        return user;
    }

    // GET: api/Users/admin
    [HttpGet("{usersecret}")]
    public async Task<ActionResult<UserResponse>> GetUserByUsersecret(string usersecret)
    {
        if (_context.Users is null)
            return NotFound();

        var user = await _userService.GetUserByUsersecretAsync(usersecret);

        if (user is null)
            return NotFound();

        return user;
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(string id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Users
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        if (_context.Users == null)
        {
            return Problem("Entity set 'LearnifyDbContext.Users'  is null.");
        }
        _context.Users.Add(user);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (UserExists(user.Id))
            {
                return Conflict();
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        if (_context.Users == null)
        {
            return NotFound();
        }
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(string id)
    {
        return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}