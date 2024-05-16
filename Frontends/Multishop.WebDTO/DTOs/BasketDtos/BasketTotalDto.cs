using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.BasketDtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }

        public string DiscountCode { get; set; }

        public int DiscountRate { get; set; }

        public IList<BasketItemDto> BasketItems { get; set; }

        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }

        public decimal DiscountPrice { get => (BasketItems.Sum(x => x.Price * x.Quantity) * (1 - (DiscountRate / 100))); }
    }
}
