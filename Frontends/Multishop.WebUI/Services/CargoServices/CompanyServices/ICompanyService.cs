using Multishop.WebDTO.DTOs.CargoDtos.CompanyDtos;

namespace Multishop.WebUI.Services.CargoServices.CompanyServices
{
    public interface ICompanyService
    {
        Task CreateCompanyAsync(CreateCompanyDto createCompanyDto);
        Task UpdateCompanyAsync(UpdateCompanyDto updateCompanyDto);
        Task DeleteCompanyAsync(int id);
        Task<UpdateCompanyDto> GetCompanyByIdAsync(int id);
        Task<IList<ResultCompanyDto>> GetAllCompaniesAsync();
    }
}
