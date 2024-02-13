using System.Collections.Generic;
using System.Threading.Tasks;
using Broidery.DataAccess.Entities;

namespace Broidery.DataAccess
{
    public interface IRepositoryReadOnly<T>
    {
        Task<T> GetByEmail(string email, string password);
        Task<T> GetByToken(string token);
        Task<bool> Exist(string token);
    }

    public interface IUserRepository : IRepositoryReadOnly<IUser>
    {
        Task<IUser> SaveToken(string email, string token);
    }

    public interface IProductRepository
    {
        Task<IEnumerable<IProduct>> GetActiveProducts();
        Task<IEnumerable<IProduct>> GetAllProducts();
        Task<IProduct> GetProductById(int id);
        Task EditProductState(int id);
        Task EditProduct(IProduct product);
        Task AddProduct(IProduct product);
    }
}