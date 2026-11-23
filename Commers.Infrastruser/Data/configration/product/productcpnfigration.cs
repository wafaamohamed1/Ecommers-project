using Ecommers.Domain.Entites.product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commers.Infrastruser.Data.configration.product
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(product => product.Description)
                .IsRequired()
                .HasMaxLength(180);
            builder.Property(product => product.Price)
                .HasColumnType("decimal(18,2)");
            builder.HasOne(product => product.ProductType)
                .WithMany(productType => productType.Products)
                .HasForeignKey(product => product.ProductTypId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(product => product.ProductBrand)
                .WithMany(productBrand => productBrand.Products)
                .HasForeignKey(product => product.ProductBrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
