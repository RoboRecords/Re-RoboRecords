using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Character
{
    [Key]
    public int CharacterId { get; set; } // Primary key for the Character

    [Required]
    [StringLength(100)]
    public string Name { get; set; } // Name of the character

    public string Description { get; set; } // Description of the character's abilities

    // Additional properties:

    // If characters have an associated image or sprite
    public string ImageUrl { get; set; }

    // Collection of Runs associated with this Character
    public virtual ICollection<Run> Runs { get; set; }

}