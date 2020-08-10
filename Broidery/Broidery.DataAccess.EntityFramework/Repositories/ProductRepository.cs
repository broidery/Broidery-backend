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
    }
}