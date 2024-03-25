using TMA_Warehouse_Models.DTOs;

namespace TMA_Warehouse_WebUI.Services;

public interface IItemService
{
    Task<IEnumerable<ItemDto>> GetItems();
}
