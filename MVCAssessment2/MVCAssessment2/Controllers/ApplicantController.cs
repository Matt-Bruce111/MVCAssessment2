using Microsoft.AspNetCore.Mvc;

namespace MVCAssessment2.Controllers
{
    public class ApplicantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
