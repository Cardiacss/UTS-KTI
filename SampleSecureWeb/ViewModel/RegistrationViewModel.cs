using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SampleSecureWeb.ViewModel
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        private string? _password;
        
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(12, ErrorMessage = "The password must be at least 12 characters long.")]
        [RegularExpression(@"^(?=.*[!@#$%^&*(),.?""{}|<>]).{12,}$", ErrorMessage = "The password must contain at least one special character.")]
        public string? Password 
        { 
            get => _password; 
            set => _password = NormalizeSpaces(value);
        }

        private string? _confirmPassword;
        
        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword 
        { 
            get => _confirmPassword; 
            set => _confirmPassword = NormalizeSpaces(value);
        }

        // Method to normalize the password input by replacing multiple spaces with a single space
        private string? NormalizeSpaces(string? input)
        {
            if (input == null) return null;

            // Replace multiple spaces with a single space
            return Regex.Replace(input, @"\s+", " ");
        }
    }
}
