namespace TMA_Warehouse_WebUI.Model;

public class ItemModel
{
    public int ItemId { get; set; }
    public ItemGroupSelection ItemGroup { get; set; }
    public UnitOfMeasurementSelection UnitOfMeasurement { get; set; }
    public int Quantity { get; set; }
    public decimal PriceWithoutVAT { get; set; }
    public string? Status { get; set; }
    public string? StorageLocation { get; set; }
    public string? ContactPerson { get; set; }
}
