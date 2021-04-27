using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SorbonneCoffee.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public float Price { get; set; }
    }
}
