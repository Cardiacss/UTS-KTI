using System;
using System.ComponentModel.DataAnnotations;

namespace SampleSecureWeb.ViewModel;

public class RegistrationViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    public string? Username { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [MinLength(12, ErrorMessage = "The password must be at least 12 characters long.")]
    [RegularExpression(@"(?=.*[!@#$%^&*(),.?""{}|<>])[A-Za-z\d!@#$%^&*(),.?""{}|<>]{12,}$", ErrorMessage = "The password must contain at least one special character.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }
}
