using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OrderService.Services;

namespace OrderService.Tests.Infrastructure;

public class ExceptionWebApplicationFactory : CustomWebApplicationFactory
{
    protected override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
    {
        base.ConfigureWebHost(webHostBuilder);

        webHostBuilder.ConfigureServices(services =>
        {
            services.RemoveAll<IOrderService>();
            services.AddScoped<IOrderService, FakeOrderService>();
        });
    }
}
