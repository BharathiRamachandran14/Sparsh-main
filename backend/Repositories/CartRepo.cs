using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sparsh.Models.Database;
using System.Linq;

namespace Sparsh.Repositories
{
    public interface ICartRepo
    {
        Cart GetAllProductsInCart(int userId);
        //Cart AddToCart(Cart newProductInCart);
        Cart DeleteFromCart(int cartId);
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

        public CartItem AddToCartItem(AddToCartItemRequest request)
        {
            CartItem newCartItem = new CartItem {
                Item = _context.Product.Single(product => product.ProductId == request.ProductId),
                Quantity = 1,
                TotalPrice = _context.Product.Single(p => p.ProductId == request.ProductId).PricePerProduct * 1,
            };

            var insertedCartItem = _context.CartItem.Add(newCartItem);
            _context.SaveChanges();
            
            return insertedCartItem.Entity;
        }

        // public Cart AddToCart(int userId)
        // {
        //     Cart newProductsInCart =new Cart {
        //         User = _context.Users.Single(user => user.UserId == userId),
        //         Products = _context.CartItem.Where(c => c.)
        //     };
            
        //     var insertedProductInCart = _context.Cart.Add(newProductInCart);
        //     _context.SaveChanges();

        //     return insertedProductInCart.Entity;
        // }

        public Cart DeleteFromCart(int cartId)
        {
            var deletedCartItem = _context.Cart.Remove(_context.Cart.Single(c => c.CartId == cartId));
            _context.SaveChanges();

            return deletedCartItem.Entity;
        }
    }
}
