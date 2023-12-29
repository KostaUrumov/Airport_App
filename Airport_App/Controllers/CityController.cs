using Airport_App_Core.Contracts;
using Airport_App_Core.Models.CityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;

        public CityController(
            ICityService _cityServ,
            ICountryService _countryService)
        {
            cityService = _cityServ;
            countryService = _countryService;
        }

        [HttpGet]
        [Authorize]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> AddNewCity()
        {
            AddNewCityModel city = new AddNewCityModel()
            {
                Countries = await countryService.AddAllCountries(),
            };
            return View(city);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> AddNewCity(AddNewCityModel city)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AddNewCity));
            }

            var isThere = cityService.CheckIfExist(city);
            if (isThere == false)
            {
                return RedirectToAction(nameof(AddNewCity));
            }

            await cityService.AddNewCity(city);

            return RedirectToAction(nameof(AllCities));
        }

        public async Task<IActionResult> AllCities()
        {
            return View(await cityService.AllCities());
        }

        [HttpGet]
        [Authorize]
        [Authorize(Policy = "AdminsOnly")]

        public async Task<IActionResult> Edit(int id)
        {
            var result = await cityService.FindCity(id);
            result.Countries = await countryService.AddAllCountries();
            return View(result);
        }

        [HttpPost]
        [Authorize]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> Edit (AddNewCityModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AllCities));
            }
            await cityService.SaveChangesAsync(model);
            return RedirectToAction(nameof(AllCities));
        }

        [Authorize]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> Delete (int id)
        {
            await cityService.Delete(id);
            return RedirectToAction(nameof(AllCities));
        }
    }
}
