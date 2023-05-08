using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCAssessment2.ViewModels;

namespace MVCAssessment2.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> userManager { get; }
        private RoleManager<IdentityRole> roleManager { get; }

        private List<string> userList;

        public AdminController(UserManager<IdentityUser> _userManager,
           RoleManager<IdentityRole> _roleManager)
        {
            this.userManager = _userManager;
            this.roleManager = _roleManager;

            //userList = new List<string>();
            //var users = userManager.users;
            // foreach (var user in users) userList.Add(user.Email);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new CreateRoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole { Name = model.RoleName };

                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded) return View("Display", roleManager.Roles);

                foreach (IdentityError e in result.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
            }
            return View("Display", roleManager.Roles);
        }

        [HttpGet]

        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            IdentityResult result = await roleManager.DeleteAsync(role);

            foreach (IdentityError e in result.Errors)
            {
                ModelState.AddModelError("", e.Description);
            }
            return View("Display", roleManager.Roles);
        }

        [HttpGet]
        public IActionResult ManageRole()
        {
            ManageRole mrole = new ManageRole();

            FillArray(mrole);
            return View(mrole);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRole(ManageRole mrole)
        {
            var role = await roleManager.FindByIdAsync(mrole.roleID);
            var user = await userManager.FindByIdAsync(mrole.userID);

            if (!(await userManager.IsInRoleAsync(user, role.Name)))
            {
                await userManager.AddToRoleAsync(user, role.Name);
            }
            return View("Display", roleManager.Roles);
        }

        private void FillArray(ManageRole mrole)
        {
            var users = userManager.Users;
            mrole.userList = new List<SelectListItem>();

            foreach (var user in users)
            {
                mrole.userList.Add(new SelectListItem { Text = user.UserName, Value = user.Id });
            }

            var roles = roleManager.Roles;
            mrole.roleList = new List<SelectListItem>();

            foreach (var role in roles)
            {
                mrole.roleList.Add(new SelectListItem { Text = role.Name, Value = role.Id });
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
