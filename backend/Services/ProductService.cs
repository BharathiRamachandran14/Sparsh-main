using Sparsh.Repositories;

namespace Sparsh.Services
{
    public interface IProductService
    {

    }
    public class ProductService : IProductService
    {
        private readonly IProductRepo _products;

        public ProductService(IProductRepo products)
        {
            _products = products;
        }
    }
}
