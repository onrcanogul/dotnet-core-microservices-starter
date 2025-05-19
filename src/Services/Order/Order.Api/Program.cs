using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Order.Application.Mappings;
using Order.Infrastructure;
using Shared.EF;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEfCoreServices<OrderContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("OrderDb")));
builder.Services.AddAutoMapper(typeof(OrderMappings));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();