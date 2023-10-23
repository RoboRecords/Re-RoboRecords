using System.ComponentModel.DataAnnotations;

namespace ReRoboRecords.Areas.Account.ViewModels;

public class LoginInputViewModel
{
    [Required]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}