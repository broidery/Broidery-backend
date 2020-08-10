using System.Collections.Generic;
using System.Threading.Tasks;
using Broidery.DataAccess;
using Broidery.DataAccess.Entities;

namespace Broidery.Interactors
{
    public class ProductsInteractor
    {
        private readonly IProductRepository productRepository;

        public ProductsInteractor(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IEnumerable<IProduct>> GetAllActiveProducts()
        {
            var entity = await productRepository.GetActiveProducts();
            return entity;
        }
        public async Task<IProduct> GetProducts(int id)
        {
            var entity = await productRepository.GetProductById(id);
            return entity;
        }
    }
}