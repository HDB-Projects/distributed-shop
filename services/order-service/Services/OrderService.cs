using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _db;
    private readonly IMapper _mapper;

    public OrderService(OrderDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<CustomerOrder>> GetAllOrdersAsync()
    {
        return await _db.CustomerOrders.ToListAsync();
    }

    public async Task<CustomerOrder> CreateOrderAsync(CreateOrderDTO createOrderDTO)
    {
        if (createOrderDTO == null)
            throw new ArgumentNullException(nameof(createOrderDTO));

        CustomerOrder customerOrder = CustomerOrder.Create(createOrderDTO.UserId, createOrderDTO.TotalAmount);

        _db.CustomerOrders.Add(customerOrder);
        await _db.SaveChangesAsync();

        return customerOrder;
    }
}
