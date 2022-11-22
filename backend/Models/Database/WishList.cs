namespace Sparsh.Models.Database
{
    public class WishList
    {  
        public int WishListId { get; set; }
        public Product Item { get; set; }
        public User User { get; set; }

    }
}
