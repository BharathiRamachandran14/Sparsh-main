using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sparsh.Models.Database;

namespace Sparsh.Repositories
{
    public interface IWishListRepo
    {
        IEnumerable<WishList> GetWIshListForUser(int userId);
        WishList AddToWishList(WishListRequest newWishListRequest);
        WishList DeleteFromWishList(int wishListId);
    }
    class WishListRepo : IWishListRepo 
    {
        private readonly SparshDbContext _context;

        public WishListRepo
        (
             SparshDbContext context
        )
        {
            _context = context;
        }

        public IEnumerable<WishList> GetWIshListForUser(int userId)
        {
            return _context.Wishlist
                .Include(w => w.Item)
                .Where(w => w.User.UserId == userId);
        }

        public WishList AddToWishList(WishListRequest newWishListRequest)
        {
            WishList newWishList = new WishList {
                Item = _context.Product.Single(product => product.ProductId == newWishListRequest.ProductId),
                User = _context.Users.Single(user => user.UserId == newWishListRequest.UserId),
            };
           
            var insertedWishList = _context.Wishlist.Add(newWishList);
            _context.SaveChanges();

            return insertedWishList.Entity;
        }

        public WishList DeleteFromWishList(int wishListId)
        {
            
            var deletedWishList = _context.Wishlist.Remove(_context.Wishlist.Single(w => w.WishListId == wishListId));
            _context.SaveChanges();

            return deletedWishList.Entity;
        } 
    }    
}