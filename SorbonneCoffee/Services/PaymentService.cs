using System.Collections.Generic;
using MongoDB.Driver;

using SorbonneCoffee.Models;

namespace SorbonneCoffee.Services
{
    public class PaymentService
    {
        private readonly IMongoCollection<Payment> _payments;

        public PaymentService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _payments = database.GetCollection<Payment>(settings.PaymentCollectionName);
        }

        public List<Payment> Get() =>
            _payments.Find(payment => true).ToList();

        public Payment Get(string id) =>
            _payments.Find<Payment>(payment => payment.Id == id).FirstOrDefault();

        public Payment Create(Payment payment)
        {
            _payments.InsertOne(payment);
            return payment;
        }

        public void Update(string id, Payment paymentIn) =>
            _payments.ReplaceOne(payment => payment.Id == id, paymentIn);

        public void Remove(Payment paymentIn) =>
            _payments.DeleteOne(payment => payment.Id == paymentIn.Id);

        public void Remove(string id) =>
            _payments.DeleteOne(payment => payment.Id == id);
    }
}
