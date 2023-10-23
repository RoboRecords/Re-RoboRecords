using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ReRoboRecords.Areas.Account.Services;
using ReRoboRecords.Areas.Account.ViewModels;

namespace ReRoboRecords.Areas.Account.Controllers;

[Area("Account")]
[Route("[area]/[action]")] // Sets route as the area name. In this case, /Account.
public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;
    private readonly IEmailSender _emailSender;
    private readonly ILogger<LoginViewModel> _loginLogger;
    private readonly ILogger<RegisterViewModel> _registerLogger;
    private readonly AccountService _accountService;



    public AccountController( UserManager<IdentityUser> userManager,
        IUserStore<IdentityUser> userStore,
        SignInManager<IdentityUser> signInManager,
        ILogger<LoginViewModel> loginLogger,
        ILogger<RegisterViewModel> registerLogger,
        IEmailSender emailSender,
        AccountService accountService)
    {
        _accountService = accountService;
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = accountService.GetEmailStore(_userManager,_userStore);
        _signInManager = signInManager;
        _registerLogger = registerLogger;
        _loginLogger = loginLogger;
        _emailSender = emailSender;
    }

    public IActionResult Index()
    {
        // This will be the manage account view most likely.
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Login(string? returnUrl = null)
    {
        
        returnUrl ??= Url.Content("~/");

        // Clear the existing external cookie to ensure a clean login process
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        
        var viewModel = new LoginViewModel
        {
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
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
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.LoginInput.Username, loginViewModel.LoginInput.Password, loginViewModel.LoginInput.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _loginLogger.LogInformation("User logged in.");
                return LocalRedirect(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = loginViewModel.LoginInput.RememberMe });
            }
            if (result.IsLockedOut)
            {
                _loginLogger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginViewModel);
            }
        }

        // If we get this far, nothing failed, so we can return the view.
        return View(loginViewModel);

    }

    [HttpGet]
    public async Task<IActionResult> Register(string returnUrl = null)
    {
        var model = new RegisterViewModel
        {
            ReturnUrl = returnUrl,
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        };
        return View(model);
    }
    
    public async Task<IActionResult> Logout(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        _loginLogger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            // This needs to be a redirect so that the browser performs a new
            // request and the identity for the user gets updated.
            return RedirectToPage("~/");
        }
    }
    
}