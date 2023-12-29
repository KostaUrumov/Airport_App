using Airport_App_Core.Contracts;
using Airport_App_Core.Models.TicketModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerService passengerService;

        public PassengerController(IPassengerService _pass)
        {
            passengerService = _pass;
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddPassengers(NumberTicketsModel numberPassengers)
        {
            List<BuyTicketsModel> passengers = new List<BuyTicketsModel>();
            for(int i = 0; i< numberPassengers.NumberOfTickets; i++)
            {
                BuyTicketsModel models = new BuyTicketsModel();
                models.FlightId = numberPassengers.FlightId;
                passengers.Add(models);
            }
            return View(passengers);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPassengers(List<BuyTicketsModel> passengers)
        {
            await passengerService.AddPassengersToFlight(passengers);
            
            return RedirectToAction("Index", "Home");
        }


    }
}
