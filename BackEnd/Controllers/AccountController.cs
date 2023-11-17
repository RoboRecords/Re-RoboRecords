using BackEnd.Data;
using FrontEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    : Controller
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterModel model)
    {
        
        Console.WriteLine("registering user");
        var user = new ApplicationUser( )
        {
            UserName = model.Username,
            Email = model.Email
        };
        var result = await userManager.CreateAsync(user, model.Password);
        Console.WriteLine("result: " + result);
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, false);
            return Ok( );
        }

        return BadRequest(result.Errors);
    }
}