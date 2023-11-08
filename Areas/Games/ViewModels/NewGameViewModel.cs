using ReRoboRecords.Areas.Games.Models;

namespace ReRoboRecords.Areas.Games.ViewModels;

public class NewGameViewModel
{
    /// <summary>
    /// Id of the Game.
    /// </summary>
    public int Id { get; set; }
        
    /// <summary>
    /// Name of the Game.
    /// </summary>
    public string? Name { get; set; }
        
    /// <summary>
    /// Description of the Game.
    /// </summary>
    public string? Description { get; set;}
        
    /// <summary>
    /// Release date of the Game.
    /// </summary>
    public string? ReleaseDate { get; set; }
        
    /// <summary>
    /// Privacy state. If private, should be hidden to non-admins.
    /// </summary>
    public bool IsPrivate { get; set; }
        
    /// <summary>
    /// Categories of the game.
    /// </summary>
    public List<Category>? Categories { get; set; }

}