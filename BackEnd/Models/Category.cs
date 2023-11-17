using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Category
{
    [Key] public int CategoryId { get; set; }

    [Required] [StringLength(255)] public string Name { get; set; }

    public int GameId { get; set; }
    public virtual Game Game { get; set; }
    public virtual ICollection<Run> Runs { get; set; }
}