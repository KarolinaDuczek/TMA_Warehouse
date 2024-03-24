using TMA_Warehouse_database.Entities;
using TMA_Warehouse_Models.DTOs;

namespace TMA_Warehouse_WebAPI.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ItemDto> ConvertToDto(this IEnumerable<Item> items)
        {
            return items.Select(i => new ItemDto
            {
                ItemGroup = i.ItemGroup,
                UnitOfMeasurement = i.UnitOfMeasurement,
                Quantity = i.Quantity,
                PriceWithoutVAT = i.PriceWithoutVAT,
                Status = i.Status,
                StorageLocation = i.StorageLocation,
                ContactPerson = i.ContactPerson,
            }).ToList();
        }
        public static ItemDto ConvertToDto(this Item i)
        {
            return new ItemDto
            {
                ItemGroup = i.ItemGroup,
                UnitOfMeasurement = i.UnitOfMeasurement,
                Quantity = i.Quantity,
                PriceWithoutVAT = i.PriceWithoutVAT,
                Status = i.Status,
                StorageLocation = i.StorageLocation,
                ContactPerson = i.ContactPerson,
            };
        }
        public static Item ConvertToEntity(this ItemDto i)
        {
            return new Item
            {
                ItemGroup = i.ItemGroup,
                UnitOfMeasurement = i.UnitOfMeasurement,
                Quantity = i.Quantity,
                PriceWithoutVAT = i.PriceWithoutVAT,
                Status = i.Status,
                StorageLocation = i.StorageLocation,
                ContactPerson = i.ContactPerson,
            };
        }
    }
}
