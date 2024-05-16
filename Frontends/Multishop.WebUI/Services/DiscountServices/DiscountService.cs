using Multishop.WebDTO.DTOs.DiscountDtos;
using System.Text.Json;

namespace Multishop.WebUI.Services.DiscountServices
{
    public class DiscountService(HttpClient _client) : IDiscountService
    {
        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            await _client.PostAsJsonAsync("discounts", createCouponDto);
        }

        public async Task DeleteCouponAsync(int id)
        {
            await _client.DeleteAsync("discounts/" + id);
        }

        public async Task<IEnumerable<ResultCouponDto>> GetAllCouponsAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<ResultCouponDto>>("discounts");
        }

        public async Task<ResultCouponDto> GetCouponByCodeAsync(string code)
        {
            var response =  await _client.GetAsync("discounts/GetCouponByCode?code=" + code);
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<ResultCouponDto>();
               
            }
            else
            {
                return new ResultCouponDto
                {
                    Code = "",
                    Rate = 0,
                    IsActive = false,
                    ValidDate = DateTime.Now

                };

            }
        }

        public async Task<ResultCouponDto> GetCouponByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<ResultCouponDto>("discounts/" + id);
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            await _client.PutAsJsonAsync("discounts", updateCouponDto);
        }
    }
}
