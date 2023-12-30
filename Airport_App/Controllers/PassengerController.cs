using Airport_App_Core.Contracts;
using Airport_App_Core.Models.TicketModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerService passengerService;
        private readonly IFlightsService flightService;

        public PassengerController(
            IPassengerService _pass,
            IFlightsService _flight
            )
        {
            passengerService = _pass;
            flightService = _flight;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddPassengers(NumberTicketsModel numberPassengers)
        {
            List<BuyTicketsModel> passengers = new List<BuyTicketsModel>();
            for(int i = 0; i< numberPassengers.NumberOfTickets; i++)
            {
                BuyTicketsModel models = new BuyTicketsModel();
                models.FlightId = numberPassengers.FlightId;
                models.Flight.Add(await flightService.GetFlight(numberPassengers.FlightId));
                passengers.Add(models);
            }
            return View(passengers);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPassengers(List<BuyTicketsModel> passengers)
        {
            var passengersToAdd = passengerService.AddPassengersToFlight(passengers);
            bool isAnyPassengerThere = await passengerService.CheckIfExist(passengersToAdd, passengers[0].FlightId);
            if (isAnyPassengerThere == true)
            {
                return RedirectToAction("Search", "Flight");
            }
            await passengerService.ReturnNewPassengers(passengersToAdd, passengers[0].FlightId);
            
            return RedirectToAction("Index", "Home");
        }


    }
}
