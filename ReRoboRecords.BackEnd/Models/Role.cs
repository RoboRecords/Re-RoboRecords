using System.ComponentModel.DataAnnotations;

namespace ReRoboRecords.BackEnd.Models;

public class Role
{
    [Key]
    public int RoleId { get; set; } // Unique identifier for the role

    [Required]
    [MaxLength(50)]
    public string RoleName { get; set; } // Name of the role (e.g., Runner, Moderator)

    // Users association
    public virtual ICollection<User> Users { get; set; } // Collection of Users with this Role
}
