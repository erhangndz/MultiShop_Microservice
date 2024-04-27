using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Dtos.ProductPhotoDtos
{
    public class ResultProductPhotoDto
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }
       
        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
