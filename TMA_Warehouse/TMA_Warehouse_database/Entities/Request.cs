using Microsoft.EntityFrameworkCore;
using TMA_Warehouse_database.EntitiesConfiguration;
using TMA_Warehouse_database.Selection;

namespace TMA_Warehouse_database.Entities
{
    [EntityTypeConfiguration(typeof(RequestEntityConfiguration))]
    public class Request
    {
        public int RequestId { get; init; }
        public string EmployeeName { get; set; }
        public int Quantity { get; set; }
        public string? Comment { get; set; }
        public StatusSelection? Status { get; set; } = 0;
        public virtual int RequestRowId { get; init; }
        public virtual RequestRow RequestRow { get; init;}
    }
}
