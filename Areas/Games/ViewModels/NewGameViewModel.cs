using System.ComponentModel.DataAnnotations;
using ReRoboRecords.Areas.Games.Models;
using ReRoboRecords.Areas.Leaderboards.Models;

namespace ReRoboRecords.Areas.Games.ViewModels;

public class NewGameViewModel
{
    /// <summary>
    /// Name of the Game.
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string GameName { get; set; }
    /// <summary>
    ///  Acronym of the Game. 
    /// </summary>
    /// <example>
    /// SRB2, SUGOI, MRCE, etc.
    /// </example>
    public string GameAcronym { get; set; }
        
    /// <summary>
    /// Description of the Game.
    /// </summary>
    [Required]
    public string? Description { get; set;}
        
    /// <summary>
    /// Release date of the Game.
    /// </summary>
    [Required]
    public DateTime ReleaseDate { get; set; }
    
    /// <summary>
    /// Image of the game.
    /// </summary>
    public IFormFile? GameImage { get; set; }
    
    /// <summary>
    /// Version of the game.
    /// </summary>
    [Required]
    [Display(Name = "Version")]
    public string GameVersion { get; set; }
    
        
    /// <summary>
    /// Categories of the game.
    /// </summary>
    public List<Category>? Categories { get; set; }

}