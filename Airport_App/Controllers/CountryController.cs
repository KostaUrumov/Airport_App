﻿using Airport_App_Core.Contracts;
using Airport_App_Core.Models.CountryModels;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService _country)
        {
            countryService = _country;
        }

        [HttpGet]
        public IActionResult AddNewCountry()
        {
            AddNewCountryModel model = new AddNewCountryModel();
            model.Continents.Add("Europe");
            model.Continents.Add("Australia");
            model.Continents.Add("North_America");
            model.Continents.Add("South_America");
            model.Continents.Add("Africa");
            model.Continents.Add("Asia");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCountry(AddNewCountryModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(AddNewCountry));
            }

            await countryService.AddNewCountry(model);

            return RedirectToAction(nameof(AllCountries));
        }

        public async Task<IActionResult> AllCountries()
        {
            return View(await countryService.GetAllCountries()) ;
        }
    }
}