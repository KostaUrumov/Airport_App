using Airport_App_Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlightsService flight;

        public HomeController(ILogger<HomeController> logger, 
            IFlightsService _flight)
        {
            _logger = logger;
            flight = _flight;
        }

        public IActionResult Index()
        {
            return View() ;
        }

        public IActionResult AddData()
        {
            return View();
        }

        [Authorize]
        public IActionResult EditData()
        {
            return View();
        }
    }
}
