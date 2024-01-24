using Airport_App_Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Areas.Manager.Controllers
{
    public class PassengerController : BaseController
    {
        private readonly IPassengerService passengerService;

        public PassengerController(IPassengerService _passService)
        {
            passengerService = _passService;   
        }
        public IActionResult GetTheMostTravellingPassengerWithDestinations()
        {
            var result =  passengerService.GetTheMostTravelingPassengerWithDestinations();
            return View(result);
        }
    }
}
