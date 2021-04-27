using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

using SorbonneCoffee.Models;

namespace SorbonneCoffee.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<Account> _accounts;

        public AccountService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            var keys = Builders<Account>.IndexKeys.Ascending("email");
            var indexOptions = new CreateIndexOptions { Unique = true };
            var model = new CreateIndexModel<Account>(keys, indexOptions);

            _accounts = database.GetCollection<Account>(settings.AccountCollectionName);
            _accounts.Indexes.CreateOne(model);
        }

        public List<Account> Get() =>
            _accounts.Find(account => true).ToList();

        public Account Get(string id) =>
            _accounts.Find<Account>(account => account.Id == id).FirstOrDefault();

        public Account GetByEmail(string email) =>
            _accounts.Find<Account>(account => account.Email == email).FirstOrDefault();

        public Account Create(Account account)
        {
            _accounts.InsertOne(account);
            return account;
        }

        public void Update(string id, Account accountIn) =>
            _accounts.ReplaceOne(account => account.Id == id, accountIn);

        public void Remove(Account accountIn) =>
            _accounts.DeleteOne(account => account.Id == accountIn.Id);

        public void Remove(string id) =>
            _accounts.DeleteOne(account => account.Id == id);
    }
}
