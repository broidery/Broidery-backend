using Broidery.DataAccess.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Broidery.DataAccess.EntityFramework.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Email).IsRequired();
            builder.Property(f => f.Name).IsRequired();
            builder.Property(f => f.Surname).IsRequired();
            builder.Property(f => f.Token).IsRequired(false);
        }
    }
}