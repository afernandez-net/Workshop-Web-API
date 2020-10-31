using Camones.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Camones.Shop.Infrastructure.EntityConfiguration
{
    public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UnitPrice)
               .HasColumnType("decimal(12,3)");
           
            builder.Ignore(x => x.IsActive);
        }
    }
}
