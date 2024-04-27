using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.CatalogDtos.ProductDetailDtos
{
    public class UpdateProductDetailDto
    {
        public string Id { get; set; }

        public string Description { get; set; }
        public string Info { get; set; }
        public string ProductId { get; set; }
    }
}
