using System.Collections.Generic;

using MongoDB.Driver;

using SorbonneCoffee.Models;

namespace SorbonneCoffee.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _Items;
        public ItemService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Items = database.GetCollection<Item>(settings.ItemCollectionName);
        }

        public List<Item> Get() => _Items.Find(Item => true).ToList();

        public Item Get(string id) =>
            _Items.Find<Item>(Item => Item.Id == id).FirstOrDefault();

        public Item Create(Item Item)
        {
            _Items.InsertOne(Item);
            return Item;
        }

        public void Update(string id, Item ItemIn)
        {
            _Items.ReplaceOne(Item => Item.Id == id, ItemIn);
        }

        public void Remove(Item ItemIn)
        {
            _Items.DeleteOne(Item => Item.Id == ItemIn.Id);
        }

        public void Remove(string id)
        {
            _Items.DeleteOne(Item => Item.Id == id);
        }
    }
}
