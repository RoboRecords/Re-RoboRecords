using Microsoft.AspNetCore.Mvc;
using ReRoboRecords.BackEnd.Models;
using ReRoboRecords.BackEnd.Data;
using ReRoboRecords.Shared;

namespace ReRoboRecords.BackEnd.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context; // Your EF Core database context
    private readonly Supabase.Client _supabaseClient; // Supabase client
    
    
    public AccountController(AppDbContext context, Supabase.Client supabaseClient)
    {
        _context = context;
        _supabaseClient = supabaseClient;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        Console.WriteLine("happening");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User()
        {
            Id = model.Id,
            Username = model.Username,
            CreatedAt = DateTime.Now,
            Bio = "I'm a test user"
        };
        
        Console.WriteLine("Model ID = " + model.Id);
        Console.WriteLine("User Id = " + user.Id);
    
        await _supabaseClient.From<User>().Insert(user);
       


        return Ok();
    }
}