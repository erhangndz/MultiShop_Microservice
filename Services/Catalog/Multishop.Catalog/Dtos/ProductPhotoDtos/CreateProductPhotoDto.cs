using MongoDB.Bson.Serialization.Attributes;
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Dtos.ProductPhotoDtos
{
    public class CreateProductPhotoDto
    {


        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ProductId { get; set; }

  
    }
}
