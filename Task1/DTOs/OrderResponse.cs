namespace Task1.DTOs;

public class OrderResponse
{
    public DateTime OrderDate { get; set; }
    public List<OrderItemsResponse> OrderItems { get; set; }
}

public class OrderItemsResponse
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}