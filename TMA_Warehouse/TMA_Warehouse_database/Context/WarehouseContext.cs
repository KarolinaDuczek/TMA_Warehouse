using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMA_Warehouse_database.Entities;

namespace TMA_Warehouse_database.Context
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions<WarehouseContext> options): base(options) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
