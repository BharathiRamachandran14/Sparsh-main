using System.ComponentModel.DataAnnotations;

namespace Sparsh.Models.Database
{
    public class WishListRequest
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public int UserId { get; set; }
    }
}
