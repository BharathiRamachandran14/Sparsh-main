using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sparsh.Models.Database
{
    public class AddToCartRequest
    {
         [Required]
        public User User { get; set; }

        [Required]
        public List<Stock> Products { get; set; }
    }
}
