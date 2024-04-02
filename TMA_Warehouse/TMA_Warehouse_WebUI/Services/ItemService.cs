using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using TMA_Warehouse_WebUI.Model;
using TMA_Warehouse_Models.DTOs;

namespace TMA_Warehouse_WebUI.Services;

public class ItemService : IItemService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManger;

    public ItemService(HttpClient http, NavigationManager navigationManger)
    {
        _http = http;
        _navigationManger = navigationManger;
    }

    public IEnumerable<ItemDto> Items { get; set; }

    public async Task AddItem(Item item)
    {
        await _http.PostAsJsonAsync("api/Item", item);
        _navigationManger.NavigateTo("items");
    }

    public async Task DeleteItem(int id)
    {
        var result = await _http.DeleteAsync($"api/Item/{id}");
        _navigationManger.NavigateTo("items");
    }

    public async Task<Item?> GetItemById(int id)
    {
        var result = await _http.GetAsync($"api/Item/{id}");
        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Item>();
        }
        return null;
    }

    public async Task GetItems()
    {
        var result = await _http.GetFromJsonAsync<IEnumerable<ItemDto>>("api/Item");
        if (result is not null)
            Items = result;
    }

    public async Task UpdateItem(int id, Item item)
    {
        await _http.PutAsJsonAsync($"api/Item/{id}", item);
        _navigationManger.NavigateTo("items");
    }
}
