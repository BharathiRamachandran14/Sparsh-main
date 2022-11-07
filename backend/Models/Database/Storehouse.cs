using System.Collections.Generic;

namespace Sparsh.Models.Database
{
    public class Storehouse 
    {  
        public int StorehouseId { get; set; }
        public List<Stock> Items { get; set; }
        public List<Transaction> transactions {get; set; }
    }
}
