using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Areas.Manager.Controllers
{
    public class PassengerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
