using MassTransit;
using Microsoft.EntityFrameworkCore;
using Notification.Api.Consumers.Order;
using Notification.Api.Contexts;
using Shared.Constants;
using Shared.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEfCoreServices<NotificationContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("NotificationDb")));


var app = builder.Build();

builder.Services.AddMassTransit(conf =>
{
    conf.AddConsumer<OrderCreatedEventConsumer>();
    conf.AddConsumer<OrderAddressChangedEventConsumer>();
    conf.UsingRabbitMq((context, configure) =>
    {
        configure.Host(builder.Configuration.GetConnectionString("RabbitMqConnection"));
        configure.ReceiveEndpoint(QueueConsts.OrderCreatedQueue, e => e.ConfigureConsumer<OrderCreatedEventConsumer>(context));
        configure.ReceiveEndpoint(QueueConsts.OrderAddressChangedQueue, e => e.ConfigureConsumer<OrderAddressChangedEventConsumer>(context));
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
