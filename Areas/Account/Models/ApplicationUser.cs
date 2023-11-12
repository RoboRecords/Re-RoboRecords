using Microsoft.AspNetCore.Identity;
using ReRoboRecords.Areas.Leaderboards.Models;

namespace ReRoboRecords.Areas.Account.Models;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Run> Runs { get; set; }
    
    
}