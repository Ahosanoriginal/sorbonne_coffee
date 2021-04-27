using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SorbonneCoffee.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("amount")]
        public float Amount { get; set; }

        [BsonElement("externalApiId")]
        public string ExternalApiId { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
