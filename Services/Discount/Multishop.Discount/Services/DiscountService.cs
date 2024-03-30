using Multishop.Discount.Dtos;

namespace Multishop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        public Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultCouponDto> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            throw new NotImplementedException();
        }
    }
}
