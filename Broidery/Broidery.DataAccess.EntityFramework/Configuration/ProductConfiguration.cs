using Broidery.DataAccess.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Broidery.DataAccess.EntityFramework.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Image).IsRequired();
            builder.Property(f => f.Description).IsRequired();
            builder.Property(f => f.Price).IsRequired();
            builder.Property(f => f.Composition).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
        }
    }
}