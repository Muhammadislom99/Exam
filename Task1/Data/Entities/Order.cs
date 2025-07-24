namespace Task1.Data.Entities;

public class Order
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<OrderItem> Items { get; set; }
}
