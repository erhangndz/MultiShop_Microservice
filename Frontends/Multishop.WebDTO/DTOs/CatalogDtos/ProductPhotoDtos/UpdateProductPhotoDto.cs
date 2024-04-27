using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.CatalogDtos.ProductPhotoDtos
{
    public class UpdateProductPhotoDto
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string ProductId { get; set; }

        public ResultProductDto Product { get; set; }
    }
}
