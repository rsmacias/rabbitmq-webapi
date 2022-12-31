using Microsoft.EntityFrameworkCore;
using Producer.Data;
using Producer.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase("AspNetCoreRabbitMQ"));

builder.Services.AddScoped<IOrderDbContext, OrderDbContext>();
builder.Services.AddScoped<IMessageProducer, MessagePublisher>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
