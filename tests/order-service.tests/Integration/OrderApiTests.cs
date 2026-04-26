using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Json;
using OrderService.Models;
using NUnit.Framework;
using OrderService.Tests.Infrastructure;

namespace OrderService.Tests.Integraton;

[TestFixture]
public class OrderApiTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _factory = new CustomWebApplicationFactory();
        _client = _factory.CreateClient();
    }
    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task Post_Order_Should_Return_Created()
    {
        // Arrange
        CreateOrderDto createOrderDto = new CreateOrderDto
        {
            UserId = Guid.NewGuid(),
            TotalAmount = 10
        };

        // Act
        HttpResponseMessage response = await _client.PostAsJsonAsync("/api/order", createOrderDto);
        CustomerOrder? result = await response.Content.ReadFromJsonAsync<CustomerOrder>();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.TotalAmount, Is.EqualTo(10));
    }

    [Test]
    public async Task Post_Order_Should_Return_BadRequest_For_Invalid_Data_Zero()
    {
        // Arrange
        CreateOrderDto createOrderDto = new CreateOrderDto
        {
            UserId = Guid.NewGuid(),
            TotalAmount = 0 // Invalid
        };

        // Act
        HttpResponseMessage response = await _client.PostAsJsonAsync("/api/order", createOrderDto);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    public async Task Post_Order_Should_Return_BadRequest_For_Invalid_Data_Negative()
    {
        // Arrange
        CreateOrderDto createOrderDto = new CreateOrderDto
        {
            UserId = Guid.NewGuid(),
            TotalAmount = -10 // Invalid
        };

        // Act
        HttpResponseMessage response = await _client.PostAsJsonAsync("/api/order", createOrderDto);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}
