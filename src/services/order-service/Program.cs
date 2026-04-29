using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Middleware;
using OSS = OrderService.Services;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Services
// --------------------

// Framework Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure
builder.Services.AddDbContext<OrderDbContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

// App
builder.Services.AddScoped<OSS.IOrderService, OSS.OrderService>();

// Mapping
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// --------------------
// Middleware Pipeline
// --------------------

// Global Exception Handling
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsEnvironment("Testing"))
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();

public partial class Program { }
