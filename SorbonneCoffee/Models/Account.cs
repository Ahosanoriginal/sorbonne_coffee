using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SorbonneCoffee.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("firstname")]
        public string Firstname { get; set; }

        [BsonElement("lastname")]
        public string Lastname { get; set; }
    }
}
