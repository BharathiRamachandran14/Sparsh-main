using Sparsh.Models.Database;
using Sparsh.Repositories;
using System;

namespace Sparsh.Services
{
    public interface ICartService
    {
        Cart GetAllProductsInCart(int userId);
        //Cart AddToCart( AddToCartItemRequest newAddToCartItemRequest);
        bool IsExistingProduct(int userId, int productId);
        Cart DeleteFromCart(int cartId);
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

        public bool IsExistingProduct(int userId, int productId)
        {
                var userCart = _cart.GetAllProductsInCart(userId);
                foreach(var item in userCart.Products)
                {
                    if(item.Item.ProductId == productId)
                    {
                        return true;
                    }
                }
                return false;
        }

        // public Cart AddToCart (AddToCartItemRequest newAddToCartItemRequest)
        // {   
        //     if(IsExistingProduct(newAddToCartItemRequest.UserId, newAddToCartItemRequest.ProductId))
        //     {
        //         throw new DuplicateWaitObjectException("Product already exists");
        //     }


        //     // double total = 0;
        //     // foreach (CartItem item in newAddToCartRequest.)
        //     // {
        //     //     total += item.Item.PricePerProduct * item.CartQuantity; 
        //     // }
        //     // Cart newCart = new Cart
        //     // {
        //     //     Products = newAddToCartRequest.Products,
        //     //     User = newAddToCartRequest.User,
        //     //     CartTotal = total,
        //     // };
        //     return _cart.AddToCart(newAddToCartRequest);
        // }

        public Cart DeleteFromCart(int cartId)
        {
            return _cart.DeleteFromCart(cartId);
        }
    }
}