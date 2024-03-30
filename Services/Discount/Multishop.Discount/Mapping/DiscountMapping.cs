using AutoMapper;
using Multishop.Discount.Dtos;
using Multishop.Discount.Entities;

namespace Multishop.Discount.Mapping
{
    public class DiscountMapping: Profile
    {
        public DiscountMapping()
        {
            CreateMap<CreateCouponDto, Coupon>().ReverseMap();
            CreateMap<UpdateCouponDto, Coupon>().ReverseMap();
            CreateMap<ResultCouponDto, Coupon>().ReverseMap();
        }
    }
}
