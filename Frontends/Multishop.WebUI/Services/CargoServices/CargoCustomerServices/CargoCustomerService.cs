using Multishop.WebDTO.DTOs.CargoDtos.CustomerDtos;
using NuGet.Versioning;

namespace Multishop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService(HttpClient _client) : ICargoCustomerService
    {
        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            await _client.PostAsJsonAsync("customers", createCustomerDto);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _client.DeleteAsync("customers/" + id);
        }

        public async Task<IList<ResultCustomerDto>> GetAllCustomersAsync()
        {
            return await _client.GetFromJsonAsync<IList<ResultCustomerDto>>("customers");
        }

        public async Task<UpdateCustomerDto> GetCustomerByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateCustomerDto>("customers/" + id);
        }

        public async Task<IList<ResultCustomerDto>> GetDetailsByUserIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<IList<ResultCustomerDto>>("customers/GetByUserId/" + id);
           
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            await _client.PutAsJsonAsync("customers", updateCustomerDto);
        }
    }
}
