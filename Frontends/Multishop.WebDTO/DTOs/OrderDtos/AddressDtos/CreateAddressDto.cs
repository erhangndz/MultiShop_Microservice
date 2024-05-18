using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.OrderDtos.AddressDtos
{
    public class CreateAddressDto
    {
        public string UserId { get; set; }
        public string Name  { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
    }
}
