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
                .Include(p => p.ProductType)
                .OrderBy(p => p.ProductType);
        }

        public IEnumerable<Product> GetProductsByType(ProductType type)
        {
            return _context.Product
                .Where(p => p.ProductType == type);
        }
    }
}
