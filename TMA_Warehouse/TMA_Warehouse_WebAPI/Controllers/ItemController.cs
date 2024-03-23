using Microsoft.AspNetCore.Mvc;
using TMA_Warehouse_database.Entities;
using TMA_Warehouse_Models.DTOs;
using TMA_Warehouse_WebAPI.Repositories;
using TMA_Warehouse_WebAPI.Extensions;

namespace TMA_Warehouse_WebAPI.Controllers
{
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

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<ItemDto>> GetItemById(int id)
        {
            try
            {
                var item = await _itemRepository.GetItem(id);
                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    var itemDtos = item.ConvertToDto();
                    return Ok(itemDtos);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<NoContentResult> AddItem(ItemDto request)
        {
            var itemToAdd = request.ConvertToEntity();
            await _itemRepository.AddItem(itemToAdd);
                return NoContent();
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult<ItemDto>> UpdateItemById(int id, Item item)
        {
            var itemToUpdate = await _itemRepository.UpdateItem(id, item);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                var itemDtos = item.ConvertToDto();
                return Ok(itemDtos);
            }
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> DeleteProductById(int id)
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
}
