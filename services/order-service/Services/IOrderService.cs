using OrderService.Models;

namespace OrderService.Services;

public interface IOrderService
{
    Task<List<CustomerOrder>> GetAllOrders();
}
