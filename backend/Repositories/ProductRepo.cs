using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sparsh.Models.Database;

namespace Sparsh.Repositories
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByType(ProductType type);
        Product AddNewProduct(Product newProduct);
        Product GetProductById(int productId);
        Product GetProductByName(string productName);
    }
    public class ProductRepo : IProductRepo
    {
        private readonly SparshDbContext _context;
        public ProductRepo 
        (
            SparshDbContext context
        )
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Product
                .OrderBy(p => p.ProductType);
        }

        public IEnumerable<Product> GetProductsByType(ProductType type)
        {
            return _context.Product
                .Where(p => p.ProductType == type);
        }

        public Product GetProductById(int productId)
        {
            return _context.Product
                .Single(p => p.ProductId == productId);
        }

        public Product GetProductByName(string productName)
        {
            return _context.Product
                .Single(p => p.ProductName == productName);
        }

        public Product AddNewProduct(Product newProduct)
        {
            var insertedProduct = _context.Product.Add(newProduct);
            _context.SaveChanges();

            return insertedProduct.Entity;
        }
    }
}
