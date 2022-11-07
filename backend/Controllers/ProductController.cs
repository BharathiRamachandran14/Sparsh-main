using Microsoft.AspNetCore.Mvc;
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
    }
}
