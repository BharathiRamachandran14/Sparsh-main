namespace Sparsh.Models.Database
{
    public class Cart
    {  
        public int CartId { get; set; }
        public Product Product { get; set; }
        public uint Quantity {get; set; }
        public double CartTotal { get; set; }
    }
}
