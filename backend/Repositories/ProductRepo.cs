using Sparsh;

namespace Sparsh.Repositories
{
    public interface IProductRepo
    {

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
    }
}
