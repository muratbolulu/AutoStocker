using AutoStocker.Api.ExceptionHandling;
using AutoStocker.Application.Services.Abstracts;
using AutoStocker.Application.Services.Concretes;
using AutoStocker.Domain.Repositories.Abstract;
using AutoStocker.Infrastructure.Clients.FakeStore;
using AutoStocker.Infrastructure.InMemories.Concretes;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<IOrderRepository, InMemoryOrderRepository>();

builder.Services.AddHttpClient<IFakeStoreClient, FakeStoreClient>();

builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 5;                // max 5 istek
        options.Window = TimeSpan.FromMinutes(1); // 1 dakikal�k pencere
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 0; // Kuyrukta bekletme yok
    }));

builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN"; // frontend bu header ile token g�nderir
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseRateLimiter();
app.UseAuthorization();

app.MapControllers();

app.Run();
