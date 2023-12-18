using Airport_App_Core.Contracts;
using Airport_App_Core.Models.Flight;
using Airport_App_Structure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class FlightController : Controller
    {
        private readonly AirportDb data;
        private readonly IFlightsService flightsService;

        public FlightController(
            AirportDb _data,
            IFlightsService _flightsService
            )
        {
            data = _data;
            flightsService = _flightsService;
                
        }
        
        public async Task<IActionResult> LastFive()
        {
            
            return View(await flightsService.TakeLastFive());
        }

        [HttpGet]
        public async Task<IActionResult> Search ()
        {
            SearchFlightModel model = new SearchFlightModel()
            {
                DepartureCity = await flightsService.GetAllCities(),
                ArrivalCity = await flightsService.GetAllCities()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchFlightModel model)
        {

            var result = await flightsService.SearchFlight(model);
            return View(nameof(Display), result);
        }

        public IActionResult Display(List<DisplayFlightModel> model)
        {
           
            return View(model);
        }

    }
}
