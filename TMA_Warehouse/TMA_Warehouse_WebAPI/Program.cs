using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TMA_Warehouse_database.Context;
using TMA_Warehouse_WebAPI.Repositories;

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

builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using var scope = app.Services.CreateScope();

var db = scope.ServiceProvider.GetRequiredService<WarehouseContext>();
db.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
