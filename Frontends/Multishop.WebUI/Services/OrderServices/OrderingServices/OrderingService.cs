using Multishop.WebDTO.DTOs.OrderDtos.OrderingDtos;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Services.OrderServices.OrderingServices
{
    public class OrderingService(HttpClient _client,IUserService _userService) : IOrderingService
    {
        public async Task CreateOrderingAsync(CreateOrderingDto ordering)
        {
            await _client.PostAsJsonAsync("orderings", ordering);
        }

        public async Task DeleteOrderingAsync(int id)
        {
            await _client.DeleteAsync("orderings/" + id);
        }

        public async Task<List<ResultOrderingDto>> GetAllOrderingsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultOrderingDto>>("orderings");
        }

        public async Task<UpdateOrderingDto> GetOrderingByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateOrderingDto>("orderings/" + id);
        }

        public async Task<List<ResultOrderingDto>> GetOrderingByUserIdAsync()
        {
            var user = await _userService.GetUserInfo();
            return await _client.GetFromJsonAsync<List<ResultOrderingDto>>("orderings/getByUserId/" +user.Id);
        }

        public async Task UpdateOrderingAsync(UpdateOrderingDto ordering)
        {
            await _client.PutAsJsonAsync("orderings", ordering);
        }
    }
}
