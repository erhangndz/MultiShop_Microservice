using Multishop.WebDTO.DTOs.OrderDtos.OrderDetailDtos;
using Multishop.WebDTO.DTOs.OrderDtos.OrderingDtos;

namespace Multishop.WebUI.Services.OrderServices.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<List<ResultOrderDetailDto>> GetAllOrderDetailsAsync();

        Task<UpdateOrderDetailDto> GetOrderDetailByIdAsync(int id);
        Task<List<ResultOrderDetailDto>> GetOrderDetailByOrderingIdAsync(int id);

        Task CreateOrderDetailAsync(CreateOrderDetailDto orderDetail);
        Task UpdateOrderDetailAsync(UpdateOrderDetailDto orderDetail);

        Task DeleteOrderDetailAsync(int id);
    }
}
