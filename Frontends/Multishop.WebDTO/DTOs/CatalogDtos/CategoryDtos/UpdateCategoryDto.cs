using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
