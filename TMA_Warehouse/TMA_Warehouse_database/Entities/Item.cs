using TMA_Warehouse_database.Selection;

namespace TMA_Warehouse_database.Entities
{
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
        public virtual RequestRow? RequestRow { get; set; }
        public virtual int RequestRowId { get; set; }

    }
}
