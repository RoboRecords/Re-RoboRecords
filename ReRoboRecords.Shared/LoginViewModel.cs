namespace ReRoboRecords.Shared;

using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
    
}
