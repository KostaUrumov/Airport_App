using Airport_App_Core.Contracts;
using Airport_App_Core.Models.FlightModels;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Areas.Manager.Controllers
{
    public class FlightController : BaseController
    {
        private readonly IFlightsService flightService;
        public FlightController(IFlightsService _flightsService)
        {
            flightService = _flightsService;
        }

        [HttpGet]
        public async Task<IActionResult> CheckRevenewByFlight()
        {
            DisplayFlightsModel newModel = new DisplayFlightsModel()
            {
                AllFlights = await flightService.GetAllFlights()
            };
            return View(newModel);
        }

        [HttpPost]
        public async Task<IActionResult> CheckRevenewByFlight(int flightId)
        {
            var result = await flightService.CheckRevenewForFlight(flightId);
            return View(nameof(Display), result);
        }

        public IActionResult Display (DisplayFlightsModel model)
        {
            return View(model);
        }

    }
}
