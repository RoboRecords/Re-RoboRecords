using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReRoboRecords.Areas.Account.ViewModels;

namespace ReRoboRecords.Areas.Account.Controllers;

[Area("Account")]
[Route("[area]/[action]")] // Sets route as the area name. In this case, /Account.
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
        // This will be the manage account view most likely.
        return View();
    }
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
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

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        var externalAuthSchemes = HttpContext.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>().GetAllSchemesAsync();
        loginViewModel.ExternalLogins = externalAuthSchemes.Result.ToList();
        
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Input.Username, loginViewModel.Input.Password, loginViewModel.Input.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return LocalRedirect(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = loginViewModel.Input.RememberMe });
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginViewModel);
            }
        }
        else
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
        }

        return View(loginViewModel);

    }
    
}