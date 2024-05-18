using Multishop.WebDTO.DTOs.OrderDtos.AddressDtos;

namespace Multishop.WebUI.Services.OrderServices.AddressServices
{
    public class AddressService(HttpClient _client) : IAddressService
    {
        public async Task CreateAddressAsync(CreateAddressDto address)
        {
            await _client.PostAsJsonAsync("addresses", address);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await _client.DeleteAsync("addresses/" + id);
        }

        public async Task<UpdateAddressDto> GetAddressByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateAddressDto>("addresses/" + id);
        }

        public async Task<List<ResultAddressDto>> GetAllAddressesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultAddressDto>>("addresses");
        }

        public async Task UpdateAddressAsync(UpdateAddressDto address)
        {
            await _client.PutAsJsonAsync("addresses", address);
        }
    }
}
