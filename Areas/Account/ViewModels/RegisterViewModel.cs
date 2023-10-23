using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ReRoboRecords.Areas.Account.ViewModels;

public class RegisterViewModel
{
    [BindProperty]
    public RegisterInputViewModel Input { get; set; }
    public string? ReturnUrl { get; set; }
    public IList<AuthenticationScheme>? ExternalLogins { get; set; }
    
    
}