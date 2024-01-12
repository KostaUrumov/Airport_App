using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Areas.Manager.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
