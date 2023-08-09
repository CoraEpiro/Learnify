using Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DbTestController : ControllerBase
{
    private readonly LearnifyDbContext _context;

    public DbTestController(LearnifyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public void GetUser()
    {
        var a = _context.Questions.ToArray();
    }
}