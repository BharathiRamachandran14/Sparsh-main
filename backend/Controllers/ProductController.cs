using System;
using Microsoft.AspNetCore.Mvc;
using Sparsh.Helpers;
using Sparsh.Models.Database;
using Sparsh.Models.Response;
using Sparsh.Services;

namespace Sparsh.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _products;
        private readonly IAuthService _authService;

        public ProductController
        (
            IProductService products,
            IAuthService authService
        )
        {
            _products = products;
            _authService = authService;
        }

        [HttpGet("")]
        public ActionResult<ListResponse<Product>> GetAllProducts()
        {
            var products = _products.GetAllProducts();
            return new ListResponse<Product>(products);
        } 

        [HttpGet("type/{productType}")]
        public ActionResult<ListResponse<Product>> GetProductsByType([FromRoute] ProductType productType)
        {
            var products = _products.GetProductsByType(productType);
            return new ListResponse<Product>(products);
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProductById([FromRoute] int productId)
        {
            try
            {
                var product = _products.GetProductById(productId);
                return product;
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpGet("name/{productName}")]
        public ActionResult<Product> GetProductByName([FromRoute] string productName)
        {
             try
            {
                var product = _products.GetProductByName(productName);
                return product;
            }
            catch(InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddProduct([FromHeader] string authorization,
                                        [FromBody] CreateProductRequest newProductRequest)
        {
            if (authorization is null)
            {
                return new UnauthorizedResult();
            }
            try
            {
                (string username, string password) = AuthHelper.GetUsernameAndPassword(authorization);

                var check = _authService.IsValidLoginInfo(username, password);
                if (!check)
                {
                    return Unauthorized();
                }
                var addedProduct = _products.AddNewProduct(newProductRequest);
                return Created("/api", addedProduct);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

        }
    }
}
