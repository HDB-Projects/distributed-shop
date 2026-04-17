using OrderService.Models;

namespace OrderService.Services;

public interface IOrderService
{
    List<CustomerOrder> GetAllOrders();
}
