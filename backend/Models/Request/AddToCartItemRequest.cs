using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sparsh.Models.Database
{
    public class AddToCartItemRequest
    {
         [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
