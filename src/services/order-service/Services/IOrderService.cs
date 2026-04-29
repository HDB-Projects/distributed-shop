using OrderService.Models;

namespace OrderService.Services;

public interface IOrderService
{
    Task<List<CustomerOrder>> GetAllOrdersAsync();
    Task<CustomerOrder?> GetOrderByIdAsync(Guid id);
    Task<CustomerOrder> CreateOrderAsync(CreateOrderDto createOrderDto);
}
