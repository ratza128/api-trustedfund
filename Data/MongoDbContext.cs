using System;
using api_trustedfund.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace api_trustedfund.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDbConnection");
            var client = new MongoClient(connectionString);
            if (client == null || string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string does not exists in appsettings");
            }

            var databaseName = configuration["MongoDbSettings:DatabaseName"];

            if (string.IsNullOrEmpty(databaseName))
            {
                throw new InvalidOperationException("Database name does not exists in appsettings");
            }

            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Trades> Trades
        {
            get
            {
                return _database.GetCollection<Trades>(typeof(Trades).Name);
            }
        }
    }
}
