using System.Collections.Generic;
using System.Threading.Tasks;
using Broidery.DataAccess;
using Broidery.DataAccess.Entities;
using Broidery.DataTransferObjects.Dtos;

namespace Broidery.Interactors
{
    public class ProductsInteractor
    {
        public class ProductUpdate : IProduct
        {
            public ProductUpdate(ProductRequestDto productRequestDto)
            {
                Id = productRequestDto.Id;
                Image = productRequestDto.Image;
                Description = productRequestDto.Description;
                Price = productRequestDto.Price;
                Composition = productRequestDto.Composition;
                IsActive = productRequestDto.IsActive;
            }

            public int Id { get; }
            public string Image { get; }
            public string Description { get; }
            public double Price { get; }
            public string Composition { get; }
            public bool IsActive { get; }
        }

        private readonly IProductRepository productRepository;

        public ProductsInteractor(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IEnumerable<IProduct>> GetAllProducts()
        {
            var entity = await productRepository.GetAllProducts();
            return entity;
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

        public async Task EditProductState(int id)
        {
            await productRepository.EditProductState(id);
        }

        public async Task EditProduct(ProductRequestDto productDto)
        {
            await productRepository.EditProduct(new ProductUpdate(productDto));
        }
    }
}