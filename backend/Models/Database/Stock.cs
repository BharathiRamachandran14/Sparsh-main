namespace Sparsh.Models.Database
{
    public class Stock 
    {  
        public int StockId { get; set; }
        public Product Item { get; set; }
        public uint Amount {get; set; }
        public double TotalPrice { get; set; }
    }
}
