using System.ComponentModel.DataAnnotations;

namespace MVCAssessment2.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
