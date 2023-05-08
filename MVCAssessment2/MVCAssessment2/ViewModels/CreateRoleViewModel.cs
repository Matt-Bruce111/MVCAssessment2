using System.ComponentModel.DataAnnotations;

namespace MVCAssessment2.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
