using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SorbonneCoffee.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("accountId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AccountId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("orders")]
        public string[] Orders { get; set; }
    }
}
