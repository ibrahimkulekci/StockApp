using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Entity
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public int UnitCode { get; set; }
        public int StockClassId { get; set; } 
        public int StockTypeId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Shelf { get; set; }
        public string? Cupboard { get; set; }
        public int CriticQantity { get; set; }
        public bool Status { get; set; }
        public int StockUnitId { get; set; }
    }
}
