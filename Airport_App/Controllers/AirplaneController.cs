using Airport_App_Core.Contracts;
using Airport_App_Core.Models.AirplaneModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Airport_App.Controllers
{
    public class AirplaneController : Controller
    {
        private readonly IAirplaneService airplaneService;
        private readonly IManufacturerServce manufacturerServce;

        public AirplaneController(
            IAirplaneService _airplaneService,
            IManufacturerServce _manufacturerServce)
        {
            airplaneService = _airplaneService;
            manufacturerServce = _manufacturerServce;
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

        [HttpGet]
        public async Task<IActionResult> AddPLane()
        {
            AddNewPlane model = new AddNewPlane()
            {
                Manufacturers = await manufacturerServce.GetAllCompanies()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPLane(AddNewPlane plane)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await airplaneService.AddAircraft(plane);

            return RedirectToAction(nameof(AllJets));
        }

        public async Task<IActionResult> AllJets()
        {
            return View(await airplaneService.GetAllPLanes());
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            var plane = await airplaneService.FindJet(id);
            plane.Manufacturers = await manufacturerServce.GetAllCompanies();
            return View(plane);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddNewPlane plane)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllJets));
            }
            await airplaneService.SaveChangesAsync(plane);
            return RedirectToAction(nameof(AllJets));
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            await airplaneService.DeleteAsync(id);
            return RedirectToAction(nameof(AllJets));
        }


    }
}
