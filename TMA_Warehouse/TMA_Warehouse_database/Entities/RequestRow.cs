using Microsoft.EntityFrameworkCore;
using TMA_Warehouse_database.EntitiesConfiguration;
using TMA_Warehouse_database.Selection;

namespace TMA_Warehouse_database.Entities
{
    [EntityTypeConfiguration(typeof(RequestRowEntityConfiguration))]
    public class RequestRow
    {
        public int RequestRowId { get; init; }
        public UnitOfMeasurementSelection UnitOfMeasurement { get; init; }
        public int Quantity { get; set;}
        public decimal PriceWithoutVAT { get; set; }
        public string? Comment { get; set; }
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        public virtual int RequestId { get; init; }
        public virtual Request Request { get; init; }
    }
}
