using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sparsh.Models.Database;
using System.Linq;

namespace Sparsh.Repositories
{
    public interface ICartRepo
    {
        Cart GetAllProductsInCart(int userId);
        Cart AddToCart(Cart newProductInCart);
    }

    public class CartRepo : ICartRepo
    {
        private readonly SparshDbContext _context;

        public CartRepo
        (
            SparshDbContext context
        )
        {
            _context = context;
        }

        public Cart GetAllProductsInCart(int userId)
        {
            return _context.Cart
                .Include(c => c.Products)
                .Single(c => c.User.UserId == userId);      
        }

        public Cart AddToCart(Cart newProductInCart)
        {
            var insertedProductInCart = _context.Cart.Add(newProductInCart);
            _context.SaveChanges();

            return insertedProductInCart.Entity;
        }
    }
}
