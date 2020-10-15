using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Broidery.DataAccess.Entities;
using Broidery.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Broidery.DataAccess.EntityFramework.Model;

namespace Broidery.DataAccess.EntityFramework.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BroideryContext context;

        public ProductRepository(BroideryContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<IProduct>> GetAllProducts()
        {
            var entity = await context.Products.ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<IProduct>> GetActiveProducts()
        {
            var entity = await context.Products.Where(f => f.IsActive == true).ToListAsync();
            return entity;
        }

        public async Task<IProduct> GetProductById(int id)
        {
            var entity = await context.Products.FirstOrDefaultAsync(f => f.Id == id);
            return entity;
        }

        public async Task EditProductState(int id)
        {

            var entity = await context.Products.FirstOrDefaultAsync(f => f.Id == id);
            if (entity != null)
            {
                if (entity.IsActive)
                {
                    entity.IsActive = false;
                    await context.SaveChangesAsync();

                }
                else
                {
                    entity.IsActive = true;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task EditProduct(IProduct product)
        {
            var entity = await context.Products.FirstOrDefaultAsync(f => f.Id == product.Id);
            if (!(entity is null))
            {

                entity.Image = product.Image;
                entity.Description = product.Description;
                entity.Price = product.Price;
                entity.Composition = product.Composition;
                entity.IsActive = product.IsActive;
                await context.SaveChangesAsync();
            }
        }
    }
}