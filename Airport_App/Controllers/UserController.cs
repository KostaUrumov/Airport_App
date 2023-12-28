using Airport_App_Core.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            AddNewUserModel user = new AddNewUserModel();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> 
    }
}
