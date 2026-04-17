using OrderService.Models;

namespace OrderService.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _db;

    public OrderService(OrderDbContext db)
    {
        _db = db;
    }

    public List<CustomerOrder> GetAllOrders()
    {
        return _db.CustomerOrders.ToList();
    }
}
