using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sparsh.Models.Database;

namespace Sparsh.Repositories
{
    public interface IWishListRepo
    {
        IEnumerable<WishList> GetWIshListForUser(int userId);
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
        
    }
}