using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;
using OSS = OrderService.Services;
using NUnit.Framework;

namespace OrderService.Tests;

[TestFixture]
public class OrderServiceTests
{
    private OrderDbContext _db;
    private OSS.OrderService _service;

    [SetUp]
    public void Setup()
    {
        DbContextOptions<OrderDbContext> options = new DbContextOptionsBuilder<OrderDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _db = new OrderDbContext(options);
        _service = new OSS.OrderService(_db, null!);
    }

    [TearDown]
    public void TearDown()
    {
        _db.Dispose();
    }

    [Test]
    public async Task CreateOrderAsync_Shoud_Create_Order()
    {
        // Arrange
        CreateOrderDto createOrderDto = new CreateOrderDto
        {
            UserId = Guid.NewGuid(),
            TotalAmount = 10
        };

        // Act
        CustomerOrder result = await _service.CreateOrderAsync(createOrderDto);
        CustomerOrder dbOrder = await _db.CustomerOrders.FirstAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.TotalAmount, Is.EqualTo(createOrderDto.TotalAmount));
        Assert.That(result.Status, Is.EqualTo("Created"));
        Assert.That(result.Id, Is.EqualTo(dbOrder.Id));
    }

    [Test]
    public void CreateOrderAsync_Should_Throw_When_Dto_Is_Null()
    {
        // Act & Assert
        Assert.That(async () => await _service.CreateOrderAsync(null!),
            Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public async Task GetAllOrdersAsync_Should_Return_Orders()
    {
        // Arrange
        CreateOrderDto createOrderDto = new CreateOrderDto
        {
            UserId = Guid.NewGuid(),
            TotalAmount = 10
        };

        // Act
        await _service.CreateOrderAsync(createOrderDto);
        List<CustomerOrder> result = await _service.GetAllOrdersAsync();

        // Assert
        Assert.That(result.Count, Is.EqualTo(1));
    }
    [Test]
    public async Task GetAllOrdersAsync_Should_Return_Empty_List_When_No_Orders()
    {
        // Act
        List<CustomerOrder> result = await _service.GetAllOrdersAsync();

        // Assert
        Assert.That(result, Is.Empty);
    }
}
