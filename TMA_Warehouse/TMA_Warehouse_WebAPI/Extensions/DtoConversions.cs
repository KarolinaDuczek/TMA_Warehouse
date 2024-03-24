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
        public static IEnumerable<RequestDto> ConvertToDto(this IEnumerable<Request> requests)
        {
            return requests.Select(i => new RequestDto
            {
                EmployeeName = i.EmployeeName,
                ItemId = i.ItemId,
                UnitOfMeasurement = i.UnitOfMeasurement,
                Quantity = i.Quantity,
                PriceWithoutVAT = i.PriceWithoutVAT,
                Comment = i.Comment,
                Status = i.Status,
            }).ToList();
        }
        public static RequestDto ConvertToDto(this Request i)
        {
            return new RequestDto
            {
                EmployeeName = i.EmployeeName,
                ItemId = i.ItemId,
                UnitOfMeasurement = i.UnitOfMeasurement,
                Quantity = i.Quantity,
                PriceWithoutVAT = i.PriceWithoutVAT,
                Comment = i.Comment,
                Status = i.Status,
            };
        }
        public static Request ConvertToEntity(this RequestDto i)
        {
            return new Request
            {
                EmployeeName = i.EmployeeName,
                ItemId = i.ItemId,
                UnitOfMeasurement = i.UnitOfMeasurement,
                Quantity = i.Quantity,
                PriceWithoutVAT = i.PriceWithoutVAT,
                Comment = i.Comment,
                Status = i.Status,
            };
        }
    }
}
