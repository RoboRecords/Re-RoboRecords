using System.ComponentModel.DataAnnotations;

namespace ReRoboRecords.BackEnd.Models;
public class Record
{
    [Key]
    public Guid RecordId { get; set; } // Unique identifier for the record

    [Required]
    public Guid UserId { get; set; } // Foreign key referencing the User

    [Required]
    public string GameTitle { get; set; } // Title of the game

    [Required]
    public string Category { get; set; } // Speedrun category (e.g., Any%, 100%, Glitchless)

    public TimeSpan Time { get; set; } // Duration of the speedrun

    public DateTime DateAchieved { get; set; } // Date when the record was set

    public string VideoUrl { get; set; } // URL to the video of the speedrun

    public string Comments { get; set; } // Additional comments or notes about the run

    // Navigation property back to the User
    public User User { get; set; }
}
