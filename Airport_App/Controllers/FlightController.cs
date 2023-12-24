using Airport_App_Core.Contracts;
using Airport_App_Core.Models.FlightModels;
using Airport_App_Structure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Airport_App.Controllers
{
    public class FlightController : Controller
    {
        private readonly AirportDb data;
        private readonly IFlightsService flightsService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly IAirportService airportService;
        private readonly IAirplaneService airplaneService;

        public FlightController(
            AirportDb _data,
            IFlightsService _flightsService,
            ICountryService _countryService,
            IAirportService _airportService,
            ICityService _cityService,
            IAirplaneService _airplaneService
            )
        {
            data = _data;
            flightsService = _flightsService;
            countryService = _countryService;
            airportService = _airportService;
            cityService = _cityService;
            airplaneService = _airplaneService;
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
                DepartureCity = await cityService.GetAllCities(),
                ArrivalCity = await cityService.GetAllCities()
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

        public async Task<IActionResult> AllFlights()
        {
            var result = await flightsService.AllFlights();
            return View(result); 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddNewFlight()
        {
            
            DateTime depart = DateTime.UtcNow;
            DateTime arrive = depart.AddMinutes(60);


            AddNewFlightModel addFlight = new AddNewFlightModel()
            {
                DepartureAirport = await airportService.AddAllAirports(),
                ArrivalAirport = await airportService.AddAllAirports(),
                AirplaneModel = await airplaneService.AddPlanes(),
                DepartureTime = DateTime.Parse(depart.ToString("dd-MM-yyyy, HH:mm")),
                ArivalTime = DateTime.Parse(arrive.ToString("dd-MM-yyyy, HH:mm")),

            };

            return View(addFlight);
        }


    }
}
