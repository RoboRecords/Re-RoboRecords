using System.ComponentModel.DataAnnotations;
using ReRoboRecords.Areas.Games.Models;

namespace ReRoboRecords.Areas.Leaderboards.Models;

public class Level
{
    [Key]
    public int LevelId { get; set; } // Primary key for the Level

    [Required]
    [StringLength(100)]
    public string Name { get; set; } // Name of the level

    [StringLength(255)]
    public string Description { get; set; } // A short description of the level

    public int GameId { get; set; }
    public virtual Game Game { get; set; }

    // Collection of Runs associated with this Level
    public virtual ICollection<Run> Runs { get; set; }

    public int Order { get; set; }
}