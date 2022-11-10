using System.Collections.Generic;
using Sparsh.Models.Database;
using Sparsh.Repositories;

namespace Sparsh.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByType(ProductType type);
        // Product GetProductById(int productId);
        Product AddNewProduct(CreateProductRequest request);        
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

        // public Product GetProductById(int productId)
        // {
        //     return _products.GetProductById(productId);
        // }

        public Product AddNewProduct(CreateProductRequest request)
        {
            Product newProduct = new Product
            {
                ProductName = request.ProductName,
                PricePerProduct = request.PricePerProduct,
                ProductImageUrl = request.ProductImageUrl,
                ProductDescription = request.ProductDescription,
                ProductType = request.ProductType,
            };
            return _products.AddNewProduct(newProduct);
        }
    }
}
