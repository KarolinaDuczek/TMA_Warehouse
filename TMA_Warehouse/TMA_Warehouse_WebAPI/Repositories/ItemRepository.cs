using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMA_Warehouse_database.Context;
using TMA_Warehouse_database.Entities;
using TMA_Warehouse_Models.DTOs;
using TMA_Warehouse_WebAPI.Extensions;

namespace TMA_Warehouse_WebAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly WarehouseContext _context;

        public ItemRepository(WarehouseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            return items;
        }

        public async Task<Item> GetItem(int id)
        {
            var item = await _context.Items
                    .FindAsync(id);
            return item;
        }

        public async Task AddItem(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Item> UpdateItem(int id, Item item)
        {
            //var itemToUpdate = item.ConvertToEntity();
            //await _context.Items
            //        .FindAsync(id);
            //if (itemToUpdate != null)
            //{
            //    itemToUpdate = item;
            //    await _context.SaveChangesAsync();
            //}
            //return item;

            var dbItem = await _context.Items.FindAsync(id);

            dbItem.ItemGroup = item.ItemGroup;
            dbItem.UnitOfMeasurement = item.UnitOfMeasurement;
            dbItem.Quantity = item.Quantity;
            dbItem.PriceWithoutVAT = item.PriceWithoutVAT;
            dbItem.Status = item.Status;
            dbItem.StorageLocation = item.StorageLocation;
            dbItem.ContactPerson = item.ContactPerson;

            await _context.SaveChangesAsync();
            return dbItem;
        }

        public async Task DeleteItem(int id)
        {
            var itemToDelete = await _context.Items
                    .FindAsync(id);
            if (itemToDelete is null)
            {
                throw new Exception("Object not found");
            }

            _context.Items.Remove(itemToDelete);
            _context.SaveChanges();
        }

    }
}
