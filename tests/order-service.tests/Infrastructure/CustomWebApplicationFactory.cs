using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OrderService.Services;
using OrderService.Data;

namespace OrderService.Tests.Infrastructure;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
    {
        webHostBuilder.UseEnvironment("Testing");

        webHostBuilder.ConfigureServices(services =>
        {
            ServiceDescriptor? descriptor = services.SingleOrDefault(d =>
            {
                return d.ServiceType == typeof(DbContextOptions<OrderDbContext>);
            });

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });
        });
    }
}
