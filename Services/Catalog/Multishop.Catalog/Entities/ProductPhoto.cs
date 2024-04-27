using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entities
{
    public class ProductPhoto : BaseEntity
    {


        public string ImageUrl { get; set; }
    
        public string ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
