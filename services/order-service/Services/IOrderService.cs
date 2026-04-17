using OrderService.Models;

namespace OrderService.Services;

public interface IOrderService
{
    Task<List<CustomerOrder>> GetAllOrdersAsync();
    Task<CustomerOrder> CreateOrderAsync(CreateOrderDTO createOrderDTO);
}
