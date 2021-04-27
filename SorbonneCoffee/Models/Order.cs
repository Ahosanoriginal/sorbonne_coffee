using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SorbonneCoffee.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("customerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }

        [BsonElement("driverId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DriverId { get; set; }

        [BsonElement("items")]
        public OrderItem[] Items { get; set; }
        
        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public string Status { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("destination")]
        public OrderDestination Destination { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("paymentId")]
        public string PaymentId { get; set; }
    }

    public class OrderItem
    {
        [BsonElement("itemId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ItemId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }

    public class OrderDestination
    {
        [BsonElement("tower")]
        public int Tower { get; set; }

        [BsonElement("room")]
        public int Room { get; set; }
    }
}

