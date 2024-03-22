using TMA_Warehouse_database.Selection;

namespace TMA_Warehouse_database.Entities
{
    public class RequestRow
    {
        public int RequestRowId { get; init; }
        public UnitOfMeasurementSelection UnitOfMeasurement { get; init; }
        public int Quantity { get; set;}
        public decimal PriceWithoutVAT { get; set; }
        public string? Comment { get; set; }
        public virtual List<Item> ItemIds { get; set; }
        public virtual int RequestId { get; init; }
        public virtual Request Request { get; init; }
    }
}
