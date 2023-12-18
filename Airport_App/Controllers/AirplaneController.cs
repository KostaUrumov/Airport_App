using Airport_App_Core.Contracts;
using Airport_App_Core.Models.Airplane;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class AirplaneController : Controller
    {
        private readonly IAirplaneService airplaneService;

        public AirplaneController(IAirplaneService _airplaneService)
        {
            airplaneService = _airplaneService;
        }

        [HttpGet]
        public async Task<IActionResult> FlightsPerAirplane()
        {
            SearchAirplaneModel model = new SearchAirplaneModel()
            {
                Aircrafts = await airplaneService.AddAllAircrafts(),

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FlightsPerAirplane(SearchAirplaneModel model)
        {
            List<DisplayAirplaneFlightsModel> result = await airplaneService.GetFlightsPerPlane(model.AircraftId);
            return View(nameof(Display), result);
        }

        public IActionResult Display(List<DisplayAirplaneFlightsModel> model)
        {
            return View(model);
        }


    }
}
