using System.ComponentModel.DataAnnotations;

namespace Sparsh.Models.Database
{
    public class CreateProductRequest
    {
        [Required]
        [StringLength(70)]
        public string ProductName { get; set; }

        [Required]
        public double PricePerProduct { get; set; }

        [Required]
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }

        [Required]
        public ProductType ProductType { get; set; }
    }
}
