using Microsoft.EntityFrameworkCore;
using ReRoboRecords.BackEnd.Models;

namespace ReRoboRecords.BackEnd.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
    public DbSet<Record> Records { get; set; }

}