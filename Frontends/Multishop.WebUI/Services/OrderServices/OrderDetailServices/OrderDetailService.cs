using Multishop.WebDTO.DTOs.OrderDtos.OrderDetailDtos;

namespace Multishop.WebUI.Services.OrderServices.OrderDetailServices
{
    public class OrderDetailService(HttpClient _client) : IOrderDetailService
    {
        public async Task CreateOrderDetailAsync(CreateOrderDetailDto orderDetail)
        {
            await _client.PostAsJsonAsync("orderDetails", orderDetail);
        }

        public async Task DeleteOrderDetailAsync(int id)
        {
            await _client.DeleteAsync("orderDetails/" + id);
        }

        public async Task<List<ResultOrderDetailDto>> GetAllOrderDetailsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultOrderDetailDto>>("orderDetails");
        }

        public async Task<UpdateOrderDetailDto> GetOrderDetailByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateOrderDetailDto>("orderDetails/" + id);
        }

        public async Task<List<ResultOrderDetailDto>> GetOrderDetailByOrderingIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<List<ResultOrderDetailDto>>("orderDetails/getByOrderingId/" + id);
        }

        public async Task UpdateOrderDetailAsync(UpdateOrderDetailDto orderDetail)
        {
            await _client.PutAsJsonAsync("orderDetails", orderDetail);
        }
    }
}
