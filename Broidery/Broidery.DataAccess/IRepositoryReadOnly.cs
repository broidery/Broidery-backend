using System.Threading.Tasks;

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
}