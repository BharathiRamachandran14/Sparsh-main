using System.ComponentModel.DataAnnotations;
using Sparsh.Models.Database;

namespace Sparsh.Models.Response
{
    public class WishListResponse
    {
        public int WishListId { get; set; }

        [Required]
        public Product Item { get; set; }

        [Required]
        public User User { get; set; }

        public WishListResponse(WishList newWishList)
        {
            this.WishListId = newWishList.WishListId;
            this.Item = newWishList.Item;
            this.User = newWishList.User;
        }
    }
}