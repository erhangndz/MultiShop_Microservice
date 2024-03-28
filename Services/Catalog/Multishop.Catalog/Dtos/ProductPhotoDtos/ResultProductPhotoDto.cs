using MongoDB.Bson.Serialization.Attributes;
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Dtos.ProductPhotoDtos
{
    public class ResultProductPhotoDto
    {
        public string Id { get; set; }

        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
