using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task1.Data.Entities;

namespace Task1.Configurations;

public class OrdersConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
       builder.Property(o=>o.Id)
           .ValueGeneratedOnAdd()
           .IsRequired()
           .HasDefaultValueSql("newid()");

       builder.Property(o => o.CreatedAt)
           .IsRequired();
    }
}