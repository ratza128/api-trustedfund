using System.Collections.Generic;
using System.Threading.Tasks;
using api_trustedfund.Data;
using api_trustedfund.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace api_trustedfund.Services
{
    public class TradeService
    {
        private readonly IMongoCollection<Trades> _trades;
        private readonly IConfiguration _configuration;

        public TradeService(MongoDbContext context, IConfiguration configuration)
        {
            _trades = context.Trades;
            _configuration = configuration;
        }

        public async Task<List<Trades>> GetAllTrades()
        {
            return await _trades.Find(_ => true).ToListAsync();
        }

        public async Task<Trades> AddNewTrade(Trades trade)
        {
            Trades newTradeToInsert = await Trades.CreateNewTradeAsync(trade, CreateNewTradeId);
            await _trades.InsertOneAsync(newTradeToInsert);

            return newTradeToInsert;
        }

        public async Task<Trades> GetTradeById(int id)
        {
            return await _trades.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        private async Task<int> CreateNewTradeId()
        {
            var lastTrade = await _trades.Find(_ => true)
            .SortByDescending(x => x.Id)
            .Limit(1)
            .FirstOrDefaultAsync();

            if (lastTrade == null)
                return 1;

            return lastTrade.Id + 1;
        }

    }
}