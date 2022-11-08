using System.Collections.Generic;
using Sparsh.Models.Database;
using Sparsh.Repositories;

namespace Sparsh.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByType(ProductType type);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepo _products;

        public ProductService(IProductRepo products)
        {
            _products = products;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products.GetAllProducts();
        }

        public IEnumerable<Product> GetProductsByType(ProductType type)
        {
            return _products.GetProductsByType(type);
        }
    }
}
