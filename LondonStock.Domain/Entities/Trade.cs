using LondonStock.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonStock.Domain.Entities
{
    public class Trade
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public Stock Stock { get; set; }
        public Guid BrokerId { get; set; }
        public User Broker { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Currency { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
