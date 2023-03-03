namespace Sparsh.Models.Database
{
    public class CartItem 
    {  
        public int CartItemId { get; set; }
        public Product Item { get; set; }
        public uint Quantity {get; set; }
        public double TotalPrice { get; set; }
    }
}
