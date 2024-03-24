using Microsoft.AspNetCore.Mvc;
using TMA_Warehouse_Models.DTOs;
using TMA_Warehouse_WebAPI.Repositories;
using TMA_Warehouse_WebAPI.Extensions;

namespace TMA_Warehouse_WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    public ItemController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
    {
        var items = await _itemRepository.GetItems();
        if (items == null)
        {
            return NotFound();
        }
        else
        {
            var itemDtos = items.ConvertToDto();
            return Ok(itemDtos);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemDto>> GetItemById(int id)
    {
        try
        {
            var item = await _itemRepository.GetItem(id);
            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                var itemDtos = item.ConvertToDto();
                return Ok(itemDtos);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<NoContentResult> AddItem(ItemDto request)
    {
        var itemToAdd = request.ConvertToEntity();
        await _itemRepository.AddItem(itemToAdd);
            return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<NoContentResult> UpdateItemById(int id, ItemDto request)
    {
        var itemToUpdate = request.ConvertToEntity();
        await _itemRepository.UpdateItem(id, itemToUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteItemById(int id)
    {
        try
        {
            await _itemRepository.DeleteItem(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
