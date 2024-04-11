using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DTO.CargoDetailDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public int Barcode { get; set; }
        public int CompanyId { get; set; }
    }
}
