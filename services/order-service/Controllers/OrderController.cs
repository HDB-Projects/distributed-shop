using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
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
    public ActionResult<List<CustomerOrder>> Get()
    {
        List<CustomerOrder> orders = _orderService.GetAllOrders();
        return Ok(orders);
    }
}
