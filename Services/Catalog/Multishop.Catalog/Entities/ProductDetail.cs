using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entities
{
    public class ProductDetail: BaseEntity
    {
        

        public string Description { get; set; }
        public string Info { get; set; }

        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
