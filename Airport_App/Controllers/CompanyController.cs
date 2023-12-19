using Airport_App_Core.Contracts;
using Airport_App_Core.Models.CompanyModels;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IManufacturerServce manufacturerServce;
        private readonly ICountryService countryService;

        public CompanyController(
            IManufacturerServce _manufacturerServce,
            ICountryService _countryService)
        {
            manufacturerServce = _manufacturerServce;
            countryService = _countryService;
        }

        [HttpGet]
        public async Task<IActionResult> AddNewCompany()
        {
            AddNewCompanyModel company = new AddNewCompanyModel()
            {
                Countries = await countryService.AddAllCountries()
            };
            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCompany(AddNewCompanyModel company)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            bool alreadyExist = manufacturerServce.CheckIfExist(company);
            if (alreadyExist == true)
            {
                return View();
            }
            await manufacturerServce.AddNewManufacturer(company);

            return RedirectToAction(nameof(AllCompanies));

        }

        public async Task<IActionResult> AllCompanies()
        {
            return View(await manufacturerServce.ReturnAllManufacturers());
        }
    }
}
