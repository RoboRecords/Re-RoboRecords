using System.ComponentModel.DataAnnotations;
using ReRoboRecords.Areas.Games.Models;

namespace ReRoboRecords.Areas.Games.ViewModels;

public class NewGameViewModel
{
    /// <summary>
    /// Name of the Game.
    /// </summary>
    [Required]
    [Display (Name = "Game Name")]
    public string Title { get; set; }
        
    /// <summary>
    /// Description of the Game.
    /// </summary>
    [Required]
    public string? Description { get; set;}
        
    /// <summary>
    /// Release date of the Game.
    /// </summary>
    [Required]
    public string? ReleaseDate { get; set; }
    
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