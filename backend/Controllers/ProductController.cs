using Microsoft.AspNetCore.Mvc;
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

        public ProductController
        (
            IProductService products
        )
        {
            _products = products;
        }

        [HttpGet("")]
        public ActionResult<ListResponse<Product>> GetAllSpecies()
        {
            var products = _products.GetAllProducts();
            return new ListResponse<Product>(products);
        } 

        [HttpGet("{productType}")]
        public ActionResult<ListResponse<Product>> GetProductsByType([FromRoute] ProductType productType)
        {
            var products = _products.GetProductsByType(productType);
            return new ListResponse<Product>(products);
        }

    }
}
