using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entities
{
    public class Category: BaseEntity
    {
       
        public string CategoryName { get; set; }
    }
}
