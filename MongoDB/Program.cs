using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://root:root@localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<Customer>("uesr");

            var customer = new Customer();
            customer.LastName = "Boer";
            collection.InsertOne(customer);
        }
    }
}
