using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _db;

    public OrderService(OrderDbContext db)
    {
        _db = db;
    }

    public async Task<List<CustomerOrder>> GetAllOrders()
    {
        return await _db.CustomerOrders.ToListAsync();
    }
}
