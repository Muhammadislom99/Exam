using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task1.Data.Entities;

namespace Task1.Configurations;

public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
      builder.HasOne(x=>x.Order)
          .WithMany(o=>o.Items)
          .HasForeignKey(x=>x.OrderId)
          .OnDelete(DeleteBehavior.Cascade);
      
      builder.Property(x=>x.ProductName)
          .IsRequired();
      
      builder.Property(x=>x.Price)
          .IsRequired();
    }
}