using System;
using System.Collections.Generic;

namespace Sparsh.Models.Database
{
    public class Transaction 
    {  
        public int TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public User Purchaser { get; set; }
        public List<Stock> DescriptionOfGoods { get; set; }
        public double TotalValue { get; set; }
        public ShippingStatus TransactionStatus { get; set; }
    }
}
