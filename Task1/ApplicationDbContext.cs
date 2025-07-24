using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Task1.Data.Entities;

namespace Task1;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }
}