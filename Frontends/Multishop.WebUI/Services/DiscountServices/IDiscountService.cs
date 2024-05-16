using Multishop.WebDTO.DTOs.DiscountDtos;

namespace Multishop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {

        Task<IEnumerable<ResultCouponDto>> GetAllCouponsAsync();

        Task<ResultCouponDto> GetCouponByCodeAsync(string code);

        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);

        Task DeleteCouponAsync(int id);
        Task<ResultCouponDto> GetCouponByIdAsync(int id);
    }
}
