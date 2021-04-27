namespace SorbonneCoffee.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string AccountCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string DriverCollectionName { get; set; }
        public string PaymentCollectionName { get; set; }
        public string ItemCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string AccountCollectionName { get; set; }
        string CustomerCollectionName { get; set; }
        string DriverCollectionName { get; set; }
        string PaymentCollectionName { get; set; }
        string ItemCollectionName { get; set; }
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
