using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CargoDtos.CompanyDtos;
using Multishop.WebUI.Services.CargoServices.CompanyServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CargoCompanyController(ICompanyService _companyService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _companyService.GetAllCompaniesAsync();
            return View(values);
        }

        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyDto createCompanyDto)
        {
            await _companyService.CreateCompanyAsync(createCompanyDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCompany(int id)
        {
            var values = await _companyService.GetCompanyByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyDto updateCompanyDto)
        {
            await _companyService.UpdateCompanyAsync(updateCompanyDto);
            return RedirectToAction("Index");
        }
    }
}
