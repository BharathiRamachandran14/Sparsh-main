namespace Sparsh.Models.Database
{
    public class Stock 
    {  
        public int StockId { get; set; }
        public Product Item { get; set; }
        public uint Quantity {get; set; }
        public double TotalPrice { get; set; }
    }
}