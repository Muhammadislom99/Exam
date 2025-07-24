using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data.Entities;
using Task1.DTOs;

namespace Task1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(ApplicationDbContext dbContext, IMapper mapper) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var order = await dbContext.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return NotFound();

        var response1= mapper.Map<OrderResponse>(order);
        return Ok(response1);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] List<AddItemDto> items)
    {
        var order = new Order();
        dbContext.Orders.Add(order);
        foreach (var orderItem in items.Select(item => new OrderItem()
                 {
                     ProductName = item.ProductName,
                     Price = item.Price,
                     OrderId = order.Id,
                 }))
        {
            dbContext.OrderItems.Add(orderItem);
        }

        await dbContext.SaveChangesAsync();
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order == null)
            return NotFound();

        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync();
        return Ok();
    }
}