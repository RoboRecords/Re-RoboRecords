using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReRoboRecords.Areas.Account.Interfaces;
using ReRoboRecords.Areas.Account.ViewModels;

namespace ReRoboRecords.Areas.Account.Services;

public class AccountService : IAccountService
{
    public IdentityUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<IdentityUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                                                $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }
    
    public IUserEmailStore<IdentityUser> GetEmailStore(UserManager<IdentityUser> _userManager, IUserStore<IdentityUser> _userStore)
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<IdentityUser>)_userStore;
    }
}