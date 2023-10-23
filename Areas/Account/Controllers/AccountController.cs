using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReRoboRecords.Areas.Account.ViewModels;

namespace ReRoboRecords.Areas.Account.Controllers;

[Area("Account")]
[Route("[area]")] // Sets route as the area name. In this case, /Account.
public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<LoginViewModel> _logger;

    public AccountController(SignInManager<IdentityUser> signInManager, ILogger<LoginViewModel> logger)
    {
        _signInManager = signInManager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
        
        returnUrl ??= Url.Content("~/");

        // Clear the existing external cookie to ensure a clean login process
        HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        
        var externalAuthSchemes = HttpContext.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>().GetAllSchemesAsync();
        var viewModel = new LoginViewModel
        {
            ExternalLogins = externalAuthSchemes.Result.ToList(),
            ReturnUrl = returnUrl
        };
        
        return View(viewModel);
    }
    
}