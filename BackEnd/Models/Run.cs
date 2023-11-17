using System.ComponentModel.DataAnnotations;
using BackEnd.Data;

namespace BackEnd.Models;

public class Run
{
    public int RunId { get; set; } // Unique identifier for the Run
    
    [Required]
    public TimeSpan Time { get; set; } // The completion time of the run
    
    [Required]
    public int CharacterId { get; set; } // The character used for the run
    public virtual Character Character { get; set; }
    
    [Required]
    public string Username { get; set; } // The username of the player
    
    [StringLength(255)]
    public string Comment { get; set; } // An optional comment about the run

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public DateTime DateSubmitted { get; set; } // The date and time the run was submitted
    
    public int GameId { get; set; } 
    public virtual Game Game { get; set; } 
    
    public int LevelId { get; set; } 
    public virtual Level Level { get; set; }

    [Url]
    public string VideoUrl { get; set; }
    
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}