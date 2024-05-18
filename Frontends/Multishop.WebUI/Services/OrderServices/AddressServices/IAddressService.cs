using Multishop.WebDTO.DTOs.OrderDtos.AddressDtos;

namespace Multishop.WebUI.Services.OrderServices.AddressServices
{
    public interface IAddressService
    {
        Task<List<ResultAddressDto>> GetAllAddressesAsync();

        Task<UpdateAddressDto> GetAddressByIdAsync(int id);

        Task CreateAddressAsync(CreateAddressDto address);
        Task UpdateAddressAsync(UpdateAddressDto address);

        Task DeleteAddressAsync(int id);


    }
}
