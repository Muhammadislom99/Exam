namespace Task1.Data.Entities;

public class OrderItem
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }
}