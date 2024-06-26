﻿using Microsoft.EntityFrameworkCore;
using TMA_Warehouse_database.EntitiesConfiguration;
using TMA_Warehouse_database.Selection;

namespace TMA_Warehouse_database.Entities
{
    [EntityTypeConfiguration(typeof(RequestEntityConfiguration))]
    public class Request
    {
        public int RequestId { get; init; }
        public string EmployeeName { get; set; }
        public int ItemId { get; set; }
        public UnitOfMeasurementSelection UnitOfMeasurement { get; init; }
        public int Quantity { get; set; }
        public decimal PriceWithoutVAT { get; set; }
        public string? Comment { get; set; }
        public StatusSelection? Status { get; set; } = 0;
        public virtual Item Item { get; set; }
    }
}
