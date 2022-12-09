using System.Collections.Generic;
using Sparsh.Models.Database;
using Sparsh.Models.Request;
using Sparsh.Repositories;

namespace Sparsh.Services
{
    public interface ICartService
    {
        Cart GetAllProductsInCart(int userId);
        Cart AddToCart(AddToCartRequest newAddToCartRequest);
    }

    public class CartService : ICartService
    {
        private readonly ICartRepo _cart;

        public CartService
        (
            ICartRepo cart
        )
        {
            _cart = cart;
        }

        public Cart GetAllProductsInCart(int userId)
        {
            return _cart.GetAllProductsInCart(userId);
        }

        public Cart AddToCart (AddToCartRequest newAddToCartRequest)
        {
            double total = 0;
            foreach (Stock item in newAddToCartRequest.Products)
            {
                total += item.Item.PricePerProduct * item.StockQuantity; 
            }
            Cart newCart = new Cart
            {
                Products = newAddToCartRequest.Products,
                User = newAddToCartRequest.User,
                CartTotal = total,
            };
            return _cart.AddToCart(newCart);
        }
    }
}