using OrderService.Models;
using OrderService.Services;

namespace OrderService.Tests.Infrastructure;

public class FakeOrderService : IOrderService
{
    public Task<List<CustomerOrder>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CustomerOrder?> GetOrderByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerOrder> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        throw new InvalidOperationException("Test Exception");
    }
}
