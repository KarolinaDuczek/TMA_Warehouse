using Microsoft.EntityFrameworkCore;
using TMA_Warehouse_database.EntitiesConfiguration;
using TMA_Warehouse_database.Selection;

namespace TMA_Warehouse_database.Entities
{
    [EntityTypeConfiguration(typeof(ItemEntityConfiguration))]
    public class Item
    {
        public int ItemId { get; init; }
        public ItemGroupSelection ItemGroup { get; set; }
        public UnitOfMeasurementSelection UnitOfMeasurement { get; set; }
        public int Quantity { get; set; }
        public decimal PriceWithoutVAT { get; set; }
        public string? Status { get; set; }
        public string? StorageLocation { get; set; }
        public string? ContactPerson { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

    }
}
