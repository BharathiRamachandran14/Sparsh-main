namespace Sparsh.Models.Database
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double PricePerProduct { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public ProductType ProductType { get; set; }

    }
}
