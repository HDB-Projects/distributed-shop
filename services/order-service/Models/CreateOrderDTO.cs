namespace OrderService.Models;

public class CreateOrderDTO
{
    public Guid UserId { get; set; }
    public decimal TotalAmount { get; set; }
}
