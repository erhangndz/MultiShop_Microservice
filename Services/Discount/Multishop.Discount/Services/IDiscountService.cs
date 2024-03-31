using Multishop.Discount.Dtos;
using Multishop.Discount.Entities;

namespace Multishop.Discount.Services
{
    public interface IDiscountService
    {
        Task<IEnumerable<ResultCouponDto>> GetAllCouponsAsync();

        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);

        Task DeleteCouponAsync(int id);
        Task<ResultCouponDto> GetCouponByIdAsync(int id);
    }
}
