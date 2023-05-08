using System.ComponentModel.DataAnnotations;

namespace MVCAssessment2.ViewModels
{
    public class RegisterViewModel
    {
        //define properties
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)] // Hide Password
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")] // Check if password and comparePassword match
        public string ConfirmPassword { get; set; }
    }
}
