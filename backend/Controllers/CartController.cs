using System;
using Microsoft.AspNetCore.Mvc;
using Sparsh.Helpers;
using Sparsh.Models.Database;
using Sparsh.Services;

namespace Sparsh.Controllers
{
    [ApiController]
    [Route("/cart")]

    public class CartController : ControllerBase
    {
        private readonly ICartService _cart;
        private readonly IAuthService _authService;

        public CartController
        (
            ICartService cart,
            IAuthService authService
        )
        {
            _cart = cart;
            _authService = authService;
        }

        [HttpGet("{userId}")]
        public ActionResult<Cart> GetAllProductsInCart([FromHeader] string authorization,
                                                       [FromRoute] int userId)
        {
            if (authorization is null)
            {
                return new UnauthorizedResult();
            }
            else
            {
                (string username, string password) = AuthHelper.GetUsernameAndPassword(authorization);

                var check = _authService.IsValidLoginInfo(username, password);
                             
                if (!check)
                {
                    return Unauthorized();
                }
                var cart = _cart.GetAllProductsInCart(userId);
                return cart;
            }
        }

    //     [HttpPost]
    //     public IActionResult AddToCart([FromHeader] string authorization,
    //                                    [FromBody] AddToCartItemRequest newAddToCartRequest)
    //     {
    //          if (authorization is null)
    //         {
    //             return new UnauthorizedResult();
    //         }
    //         try
    //         {
    //             (string username, string password) = AuthHelper.GetUsernameAndPassword(authorization);

    //             var check = _authService.IsValidLoginInfo(username, password);
                             
    //             if (!check)
    //             {
    //                 return Unauthorized();
    //             }
    //             var newCart = _cart.AddToCart(newAddToCartRequest);
    //             return Created("/api", newCart);
    //         }
    //         catch (ArgumentOutOfRangeException)
    //         {
    //             return BadRequest();
    //         }
    //         catch (ArgumentException)
    //         {
    //             return BadRequest();
    //         }
    //         catch (InvalidOperationException)
    //         {
    //             return NotFound();
    //         }
    //     }
     }
}