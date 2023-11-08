using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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


    public AccountController(UserManager<IdentityUser> userManager,
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
        _emailStore = accountService.GetEmailStore(_userManager, _userStore);
        _signInManager = signInManager;
        _registerLogger = registerLogger;
        _loginLogger = loginLogger;
        _emailSender = emailSender;
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
    public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        var externalAuthSchemes = HttpContext.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>()
            .GetAllSchemesAsync();
        loginViewModel.ExternalLogins = externalAuthSchemes.Result.ToList();

        // If somehow the model is invalid, return the same page
        if (!ModelState.IsValid) 
            return View(loginViewModel);
        
        IdentityUser? user;
            
        if (MailAddress.TryCreate(loginViewModel.LoginInput.UsernameOrEmail, out var emailAddress))
        {
            user = await _emailStore.FindByEmailAsync(emailAddress.Address, CancellationToken.None);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "No user found with that email address.");
                return View(loginViewModel);
            }
        }
        else
        {
            user = await _userManager.FindByNameAsync(loginViewModel.LoginInput.UsernameOrEmail);
                
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "No user found with that username");
                return View(loginViewModel);
            }
        }

        var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.LoginInput.Password,
            loginViewModel.LoginInput.RememberMe, lockoutOnFailure: false);
            
        if (result.Succeeded)
        {
            _loginLogger.LogInformation("User logged in.");
            return LocalRedirect(returnUrl);
        }
        if (result.RequiresTwoFactor)
        {
            return RedirectToPage("./LoginWith2fa",
                new { ReturnUrl = returnUrl, loginViewModel.LoginInput.RememberMe });
        }
        if (result.IsLockedOut)
        {
            _loginLogger.LogWarning("User account locked out.");
            return RedirectToPage("./Lockout");
        }
        
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(loginViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Register(string? returnUrl = null)
    {
        var viewModel = new RegisterViewModel
        {
            ReturnUrl = returnUrl,
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        if (ModelState.IsValid)
        {
            var user = _accountService.CreateUser();

            await _userStore.SetUserNameAsync(user, model.Input.Username, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, model.Input.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, model.Input.Password);

            if (result.Succeeded)
            {
                _registerLogger.LogInformation("User created a new account with password.");

                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Action(
                    "ConfirmEmail", "Account",
                    new
                    {
                        userId,
                        code,
                        returnUrl
                    });
;

                await _emailSender.SendEmailAsync(model.Input.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return View("RegisterConfirmation",
                        new RegisterConfirmationViewModel
                        {
                            Email = model.Input.Email,
                            DisplayConfirmAccountLink = true,
                            EmailConfirmationUrl = callbackUrl
                        });
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If we got this far, something failed, redisplay form
        return View(model);
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string userId, string code, string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");
        if (userId == null || code == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{userId}'.");
        }

        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
        }

        return View();
    }

    public async Task<IActionResult> Logout(string? returnUrl = null)
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