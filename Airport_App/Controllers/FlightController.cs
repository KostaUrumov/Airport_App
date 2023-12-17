using Airport_App_Core.Contracts;
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
    }
}
