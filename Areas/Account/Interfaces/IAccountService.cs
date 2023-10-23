using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ReRoboRecords.Areas.Account.Interfaces;

public interface IAccountService
{

    public IdentityUser CreateUser();
    public IUserEmailStore<IdentityUser> GetEmailStore(UserManager<IdentityUser> _userManager, IUserStore<IdentityUser> _userStore);
}