using BackEnd.Models;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.Data;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Run> Runs { get; set; }
}