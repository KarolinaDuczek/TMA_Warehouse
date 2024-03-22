using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TMA_Warehouse_database.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WarehouseContext>(configuration =>
{
    configuration
    .UseSqlServer(builder.Configuration.GetConnectionString("TMA_Warehouse"),
    sqlOptions => sqlOptions.MigrationsAssembly(nameof(TMA_Warehouse_database)))
    .LogTo(Console.WriteLine, LogLevel.Information);
});

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
