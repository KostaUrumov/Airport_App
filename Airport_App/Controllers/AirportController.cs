using Airport_App_Core.Contracts;
using Airport_App_Core.Models.AirportModels;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportService airportService;
        private readonly ICityService cityService;

        public AirportController(
            IAirportService _airportService,
            ICityService _city)
        {
            airportService = _airportService;
            cityService = _city;
        }

        [HttpGet]
        public async Task<IActionResult> AddNewAirport()
        {
            AddNewAirportModel model = new AddNewAirportModel()
            {
                Cityies = await cityService.GetAllCities()
            };
            return View(model);
        }

        public async Task<IActionResult> AddNewAirport(AddNewAirportModel port)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AddNewAirport));
            }
            var isThere = airportService.CheckIfExist(port);
            if (isThere == true) 
            {
                return RedirectToAction(nameof(AddNewAirport));
            }

            await airportService.AddNewAirport(port);

            return RedirectToAction(nameof(AllAirports));
        }

        public async Task<IActionResult> AllAirports()
        {
            return View(await airportService.GetAllAirports());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var airport = await airportService.FindAirport(id);
            airport.Cityies = await cityService.GetAllCities();
            return View(airport);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddNewAirportModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllAirports));
            }

            await airportService.SaveChangesAsync(model);
            return RedirectToAction(nameof(AllAirports));
        }

        public async Task<IActionResult> Delete (int id)
        {
            await airportService.DeleteAsync(id);
            return RedirectToAction(nameof(AllAirports));
        }

    }
}
