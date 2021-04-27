using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SorbonneCoffee.Models
{
    public class Driver
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

        [BsonElement("commission")]
        public float Commission { get; set; }

        [BsonElement("available")]
        public bool Available { get; set; }
    }
}
