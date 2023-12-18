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
        private readonly ICountryService countryService;
        private readonly IContinentService continentService;
        private readonly IAirportService airportService;

        public FlightController(
            AirportDb _data,
            IFlightsService _flightsService,
            ICountryService _countryService,
            IContinentService continentService,
            IAirportService _airportService
            )
        {
            data = _data;
            flightsService = _flightsService;
            countryService = _countryService;
            airportService = _airportService;
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

        [HttpGet]
        public async Task<IActionResult> FilterByCountry()
        {
            FilterByCountryModel model = new FilterByCountryModel()
            {
                Countries = await countryService.AddAllCountries()
            };
            

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByCountry(int countryId)
        {
            var result = await flightsService.AllByCountryDeparture (countryId);
            return View(nameof(Display), result);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByDepartureAirport()
        {
            FilterByDepartureAirportModel model = new FilterByDepartureAirportModel()
            {
                Airports = await airportService.AddAllAirports()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByDepartureAirport(int airportId)
        {
            var result = await flightsService.FilterByDepartureAirport(airportId);
            return View(nameof(Display), result);
        }


        public IActionResult Filter()
        {
            return View();
        }

    }
}
