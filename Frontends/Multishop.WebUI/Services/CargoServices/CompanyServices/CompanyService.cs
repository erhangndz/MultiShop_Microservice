using Multishop.WebDTO.DTOs.CargoDtos.CompanyDtos;

namespace Multishop.WebUI.Services.CargoServices.CompanyServices
{
    public class CompanyService(HttpClient _client) : ICompanyService
    {
        public async Task CreateCompanyAsync(CreateCompanyDto createCompanyDto)
        {
            await _client.PostAsJsonAsync("companies", createCompanyDto);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _client.DeleteAsync("companies/" + id);
        }

        public async Task<IList<ResultCompanyDto>> GetAllCompaniesAsync()
        {
            return await _client.GetFromJsonAsync<IList<ResultCompanyDto>>("companies");
        }

        public async Task<UpdateCompanyDto> GetCompanyByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateCompanyDto>("companies/" + id);
        }

        public async Task UpdateCompanyAsync(UpdateCompanyDto updateCompanyDto)
        {
            await _client.PutAsJsonAsync("companies", updateCompanyDto);
        }
    }
}
