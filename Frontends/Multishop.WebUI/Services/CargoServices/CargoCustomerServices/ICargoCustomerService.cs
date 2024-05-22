using Multishop.WebDTO.DTOs.CargoDtos.CustomerDtos;

namespace Multishop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {

        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomerAsync(int id);
        Task<UpdateCustomerDto> GetCustomerByIdAsync(int id);
        Task<IList<ResultCustomerDto>> GetDetailsByUserIdAsync(string id);
        Task<IList<ResultCustomerDto>> GetAllCustomersAsync();
    }
}
