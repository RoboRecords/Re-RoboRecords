using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReRoboRecords.Areas.Games.Models;
using ReRoboRecords.Areas.Runs.Models;

namespace ReRoboRecords.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Game> Games { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Run> Runs { get; set; }
}
