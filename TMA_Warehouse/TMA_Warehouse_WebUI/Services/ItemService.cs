using System.Net.Http.Json;
using TMA_Warehouse_Models.DTOs;

namespace TMA_Warehouse_WebUI.Services;

public class ItemService : IItemService
{
    private readonly HttpClient _httpClient;

    public ItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ItemDto>> GetItems()
    {
        try
        {
            var items = await _httpClient.GetFromJsonAsync<IEnumerable<ItemDto>>("api/Item");
            return items;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
