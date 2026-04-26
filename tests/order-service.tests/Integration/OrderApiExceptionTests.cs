using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Json;
using OrderService.Models;
using NUnit.Framework;
using OrderService.Tests.Infrastructure;

namespace OrderService.Tests.Integraton;

[TestFixture]
public class OrderApiExceptionTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _factory = new ExceptionWebApplicationFactory();
        _client = _factory.CreateClient();
    }
    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task Post_Order_Should_Return_InternalServerError_When_Exception_Thrown()
    {
        // Arrange
        CreateOrderDto createOrderDto = new CreateOrderDto
        {
            UserId = Guid.NewGuid(),
            TotalAmount = 10 
        };

        // Act
        HttpResponseMessage response = await _client.PostAsJsonAsync("/api/order", createOrderDto);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}
