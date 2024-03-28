using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
