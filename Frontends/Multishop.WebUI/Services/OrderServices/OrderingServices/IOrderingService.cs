using Multishop.WebDTO.DTOs.OrderDtos.AddressDtos;
using Multishop.WebDTO.DTOs.OrderDtos.OrderingDtos;

namespace Multishop.WebUI.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        Task<List<ResultOrderingDto>> GetAllOrderingsAsync();

        Task<UpdateOrderingDto> GetOrderingByIdAsync(int id);
        Task<List<ResultOrderingDto>> GetOrderingByUserIdAsync();

        Task CreateOrderingAsync(CreateOrderingDto ordering);
        Task UpdateOrderingAsync(UpdateOrderingDto ordering);

        Task DeleteOrderingAsync(int id);
    }
}
