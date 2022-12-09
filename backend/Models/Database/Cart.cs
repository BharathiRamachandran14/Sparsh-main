using System.Collections.Generic;

namespace Sparsh.Models.Database
{
    public class Cart
    {  
        public int CartId { get; set; }
        public User User {get; set;}
        public List<Stock> Products { get; set; }
        public double CartTotal { get; set; }
    }
}
