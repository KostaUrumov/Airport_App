using Airport_App_Core.Contracts;
using Airport_App_Core.Models.FlightModels;
using Airport_App_Core.Models.TicketModels;
using Airport_App_Structure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                ArrivalCity = await cityService.GetAllCities(),
                DepartureDate = DateTime.UtcNow

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
        [Authorize]
        public async Task<IActionResult> FilterByCountry()
        {
            FilterByCountryModel model = new FilterByCountryModel()
            {
                Countries = await countryService.AddAllCountries()
            };
            

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> FilterByCountry(int countryId)
        {
            var result = await flightsService.AllByCountryDeparture (countryId);
            return View(nameof(Display), result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> FilterByDepartureAirport()
        {
            FilterByDepartureAirportModel model = new FilterByDepartureAirportModel()
            {
                Airports = await airportService.AddAllAirports()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> FilterByDepartureAirport(int airportId)
        {
            var result = await flightsService.FilterByDepartureAirport(airportId);
            return View(nameof(Display), result);
        }

        [Authorize]
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
        [Authorize]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> Edit(int id)
        {
            

            var result  = await flightsService.FindFlight(id);

            result.Departures = await airportService.AddAllAirports();
            result.ArrivalAirport = await airportService.AddAllAirports();
            //result.DepartureTime = DateTime.Parse(depart.ToString("dd-MM-yyyy, HH:mm"));
            //result.ArivalTime = DateTime.Parse(arrive.ToString("dd-MM-yyyy, HH:mm"));
            result.AirplaneModel = await airplaneService.AddPlanes();
            
            return View(result);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Policy = "AdminsOnly")]

        public async Task<IActionResult> Edit(AddNewFlightModel addFlight)
        {
            
            await flightsService.SaveChangesAsync(addFlight);
            return RedirectToAction(nameof(AllFlights));

        }


        [HttpGet]
        [Authorize]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> AddNewFlight()
        {
            
            DateTime depart = DateTime.UtcNow;
            DateTime arrive = depart.AddMinutes(60);


            AddNewFlightModel addFlight = new AddNewFlightModel()
            {
                Departures = await airportService.AddAllAirports(),
                ArrivalAirport = await airportService.AddAllAirports(),
                AirplaneModel = await airplaneService.AddPlanes(),
                DepartureTime = DateTime.Parse(depart.ToString("dd-MM-yyyy, HH:mm")),
                ArivalTime = DateTime.Parse(arrive.ToString("dd-MM-yyyy, HH:mm")),

            };

            return View(addFlight);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> AddNewFlight(AddNewFlightModel addFlight)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllFlights));
            }
            
            var differentAirport = flightsService.CheckAirports(addFlight);
            if (differentAirport == false)
            {
                return RedirectToAction(nameof(AllFlights));
            }

            var checkDifferentDates = flightsService.CheckDates(addFlight);
            if (checkDifferentDates == false)
            {
                return RedirectToAction(nameof(AllFlights));
            }


            await flightsService.AddNewFlight(addFlight);

            return RedirectToAction(nameof(AllFlights));
            
        }

        [HttpGet]
        [Authorize]
        public async Task< IActionResult> BuyTickets(int id)
        {
            NumberTicketsModel numberPassengers = new NumberTicketsModel();
            numberPassengers.FlightId = id;
            numberPassengers.Flight.Add(await flightsService.GetFlight(id));
            return View(numberPassengers);
        }

        [HttpPost]
        [Authorize]
        public IActionResult BuyTickets(NumberTicketsModel numberPassengers)
        {
            return RedirectToAction("AddPassengers", "Passenger", numberPassengers);
        }
    }
}
