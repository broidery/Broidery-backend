using System.Threading.Tasks;
using Broidery.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Broidery.DataAccess.EntityFramework.Repositories
{
    public class UserRepository : IRepositoryReadOnly<IUser>, IUserRepository
    {
        private readonly BroideryContext context;

        public UserRepository(BroideryContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exist(string token)
        {
            var entity = await context.Users.FirstOrDefaultAsync(f => f.Token == token);
            return entity == null ? false : true;
        }

        public async Task<IUser> GetByEmail(string email, string password)
        {
            var entity = await context.Users.FirstOrDefaultAsync(f => f.Email == email && f.Password == password);
            return entity;
        }

        public async Task<IUser> GetByToken(string token)
        {
            var entity = await context.Users.FirstOrDefaultAsync(f => f.Token == token);
            return entity;
        }

        public async Task<IUser> SaveToken(string email, string token)
        {
            var entity = await context.Users.FirstOrDefaultAsync(f => f.Email.ToLower() == email.ToLower());
            entity.Token = token;
            context.SaveChanges();
            return entity;
        }
    }
}