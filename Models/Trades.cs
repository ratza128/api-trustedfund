using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace api_trustedfund.Models
{
    public class Trades
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Unit { get; set; }

        [Required]
        public string Parity { get; set; }

        [Required]
        public DateTime Entry { get; set; }

        [Required]
        public int Position { get; set; }

        // public string PositionFormatter
        // {
        //     get
        //     {
        //         return Position == (int)PositionEnum.Long ? "L" : "S";
        //     }
        // }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public DateTime Exit { get; set; }

        [Required]
        public decimal Procent { get; set; }

        // public string ProcentFormatted
        // {
        //     get
        //     {
        //         return Procent < 0 ? $"({Procent:0.0})" : Procent.ToString("0.0");
        //     }
        // }
        [Required]
        public decimal Profit { get; set; }
        // public string ProfitFormatted
        // {
        //     get
        //     {
        //         return Profit < 0 ? $"({Profit:0.0})" : Profit.ToString("0.0");
        //     }
        // }

        [Required]
        public decimal Total { get; set; }
        // public string TotalFormatted
        // {
        //     get
        //     {
        //         return Total < 0 ? $"({Total:0.0})" : Total.ToString("0.0");
        //     }
        // }


        public static async Task<Trades> CreateNewTradeAsync(Trades newTradeToAdd, Func<Task<int>> generateIdFunc) // fie putem sa adaugam inca un parametru Func<Task<int>> generateIdFunc pe care sa-l trimit ca parametru
        {
            int id = await generateIdFunc();

            return new Trades
            {
                Id = id,
                Unit = newTradeToAdd.Unit,
                Parity = newTradeToAdd.Parity,
                Entry = newTradeToAdd.Entry,
                Position = newTradeToAdd.Position,
                Price = newTradeToAdd.Price,
                Quantity = newTradeToAdd.Quantity,
                Exit = newTradeToAdd.Exit,
                Procent = newTradeToAdd.Procent,
                Profit = newTradeToAdd.Profit,
                Total = newTradeToAdd.Total
            };
        }
    }


    public enum PositionEnum
    {
        Long,
        Short
    }
}