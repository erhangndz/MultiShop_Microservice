using Dapper;
using Multishop.Discount.Context;
using Multishop.Discount.Dtos;
using System.Data;

namespace Multishop.Discount.Services
{
    public class DiscountService(DiscountContext _context) : IDiscountService
    {
        private readonly IDbConnection _connection = _context.CreateConnection();
        public async Task CreateCouponAsync(CreateCouponDto dto)
        {
            var query = $"insert into coupons (code,rate,IsActive,validdate) values (@Code,@Rate,@IsActive,@ValidDate)";

            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(dto);
            await _connection.ExecuteAsync(query, parameters);

        }

        public async Task DeleteCouponAsync(int id)
        {
            var query = $"delete from coupons where CouponId={id}";
            await _connection.ExecuteAsync(query);
        }

        public async Task<IEnumerable<ResultCouponDto>> GetAllCouponsAsync()
        {
            var query = "select * from coupons";
            return await _connection.QueryAsync<ResultCouponDto>(query);
        }

        public async Task<ResultCouponDto> GetCouponByIdAsync(int id)
        {

            var query = $"select * from coupons where CouponId={id}";
            return await _connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query);
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            var query = $"update coupons set Code=@Code,rate=@Rate,Isactive=@IsActive,validdate=@ValidDate where CouponId={updateCouponDto.CouponId}";
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(updateCouponDto);

            await _connection.ExecuteAsync(query, parameters);
        }
    }
}
