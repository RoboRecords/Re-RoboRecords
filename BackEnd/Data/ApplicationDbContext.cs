using BackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Game> Games { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Level> Levels { get; set; }

    public DbSet<Run> Runs { get; set; }

    public DbSet<Character> Characters { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define a one-to-many relationship between Game and Category
        modelBuilder.Entity<Game>()
            .HasMany(g => g.Categories)
            .WithOne(c => c.Game)
            .HasForeignKey(c => c.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        // Define a one-to-many relationship between Runs and Category 
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Runs)
            .WithOne(r => r.Category)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);


        // Configure the one-to-many relationship between ApplicationUser and Run
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Runs)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Unique constraint for Category Name within a Game
        modelBuilder.Entity<Category>()
            .HasIndex(c => new { c.Name, c.GameId })
            .IsUnique();
    }
}