using System.Collections.Generic;

using MongoDB.Driver;

using SorbonneCoffee.Models;

namespace SorbonneCoffee.Services
{
    public class DriverService
    {
        private readonly IMongoCollection<Driver> _drivers;
        public DriverService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _drivers = database.GetCollection<Driver>(settings.DriverCollectionName);
        }

        public List<Driver> Get() => _drivers.Find(driver => true).ToList();

        public List<Driver> Get(bool? available) => _drivers.Find(
            driver => driver.Available == available).ToList();

        public Driver Get(string id) =>
            _drivers.Find<Driver>(driver => driver.Id == id).FirstOrDefault();

        public Driver Create(Driver driver)
        {
            _drivers.InsertOne(driver);
            return driver;
        }

        public void Update(string id, Driver driverIn)
        {
            _drivers.ReplaceOne(driver => driver.Id == id, driverIn);
        }

        public void Remove(Driver driverIn)
        {
            _drivers.DeleteOne(driver => driver.Id == driverIn.Id);
        }

        public void Remove(string id)
        {
            _drivers.DeleteOne(driver => driver.Id == id);
        }
    }
}
