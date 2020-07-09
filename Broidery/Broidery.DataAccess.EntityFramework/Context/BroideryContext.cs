using System.Threading.Tasks;
using Broidery.DataAccess.EntityFramework.Configuration;
using Broidery.DataAccess.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace Broidery.DataAccess.EntityFramework.Context
{
    public class BroideryContext : DbContext
    {
        private static bool HasBeenMigrated = false;
        private static readonly object _lock = new object();
        private static void Migrate(BroideryContext instance)
        {
            if (HasBeenMigrated) return;

            lock (_lock)
            {
                if (!HasBeenMigrated)
                {
                    instance.Database.Migrate();
                    HasBeenMigrated = true;
                }
            }
        }

        public DbSet<User> Users { get; set; }

        public BroideryContext(DbContextOptions<BroideryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public async Task Migrate()
        {
            await Database.MigrateAsync();
        }
    }
}