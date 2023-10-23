using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ReRoboRecords.Areas.Account.ViewModels;

public class LoginViewModel
{
    [BindProperty]
    public LoginInputViewModel LoginInput { get; set; }
    public IList<AuthenticationScheme>? ExternalLogins { get; set; }
    public string? ReturnUrl { get; set; }
    [TempData]
    public string? ErrorMessage { get; set; }

}