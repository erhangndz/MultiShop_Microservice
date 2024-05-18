using Multishop.WebDTO.DTOs.OrderDtos.OrderDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.OrderDtos.OrderingDtos
{
    public class ResultOrderingDto
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ResultOrderDetailDto> OrderDetails { get; set; }
    }
}
