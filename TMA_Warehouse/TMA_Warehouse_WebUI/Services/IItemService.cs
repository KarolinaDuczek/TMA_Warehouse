using TMA_Warehouse_Models.DTOs;
using TMA_Warehouse_WebUI.Model;

namespace TMA_Warehouse_WebUI.Services;

public interface IItemService
{
    //Task<IEnumerable<ItemDto>> GetItems();
    //Task<ItemDto?> GetProductById(int id);
    //Task AddItem(Item it);

    IEnumerable<ItemDto> Items { get; set; }
    Task GetItems();
    Task<ItemModel?> GetItemById(int id);
    Task AddItem(ItemModel item);
    Task UpdateItem(int id, ItemModel item);
    Task DeleteItem(int id);
}
