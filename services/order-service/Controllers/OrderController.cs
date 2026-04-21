using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Controllers;
using OSS = OrderService.Services;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OSS.IOrderService _orderService;

    public OrderController(OSS.IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerOrder>>> GetAllOrders()
    {
        List<CustomerOrder> orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<CustomerOrder>> GetById(Guid id)
    // {
        // var order = await _orderService.GetOrderByIdAsync(id);

        // if (order == null)
        //     return NotFound();

        // return Ok(order);
    // }

    [HttpPost]
    public async Task<ActionResult<CustomerOrder>> CreateOrder(CreateOrderDTO createOrderDTO)
    {
        CustomerOrder order = await _orderService.CreateOrderAsync(createOrderDTO);

        return CreatedAtAction(nameof(GetAllOrders), new { id = order.Id }, order);
    }
}
