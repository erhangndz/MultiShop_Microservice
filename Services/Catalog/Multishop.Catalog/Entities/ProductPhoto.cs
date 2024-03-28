using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entities
{
    public class ProductPhoto: BaseEntity
    {
        

        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
