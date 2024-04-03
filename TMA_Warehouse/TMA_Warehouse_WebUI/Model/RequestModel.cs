using TMA_Warehouse_database.Selection;

namespace TMA_Warehouse_WebUI.Model
{
    public class RequestModel
    {
        public string EmployeeName { get; set; }
        public int ItemId { get; set; }
        public UnitOfMeasurementSelection UnitOfMeasurement { get; init; }
        public int Quantity { get; set; }
        public decimal PriceWithoutVAT { get; set; }
        public string? Comment { get; set; }
        public StatusSelection? Status { get; set; } = 0;
    }
}
