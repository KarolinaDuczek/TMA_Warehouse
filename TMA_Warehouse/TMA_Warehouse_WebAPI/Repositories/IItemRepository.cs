using TMA_Warehouse_database.Entities;
using TMA_Warehouse_Models.DTOs;

namespace TMA_Warehouse_WebAPI.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(int id);
        Task AddItem(Item item);
        Task DeleteItem(int id);
        Task<Item> UpdateItem(int id, Item item);
    }
}
