using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCAssessment2.ViewModels
{
    public class ManageRole
    {
        public string userID { get; set; }

        public string roleID { get; set; }

        public List<SelectListItem> userList = new List<SelectListItem>();
        public List<SelectListItem> roleList = new List<SelectListItem>();
    }
}
