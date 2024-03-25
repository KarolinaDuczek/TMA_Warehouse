using Microsoft.AspNetCore.Components;
using TMA_Warehouse_Models.DTOs;
using TMA_Warehouse_WebUI.Services;

namespace TMA_Warehouse_WebUI.Pages;

public class ItemsBase : ComponentBase
{
    [Inject]
    public IItemService ItemService { get; set; }
    public IEnumerable<ItemDto> Items { get; set; }
    protected override async Task OnInitializedAsync()
    {
        Items = await ItemService.GetItems();
    }
}
