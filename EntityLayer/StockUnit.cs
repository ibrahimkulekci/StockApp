using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Entity
{
    public class StockUnit
    {
        [Key]
        public int Id { get; set; }
        public int UnitCode { get; set; } = 0;
        public int StockTypeId { get; set; } //stocktype
        public int QuantityUnitId { get; set; } //adet, m3, Gram vb.
        public string? Description { get; set; }
        public float BuyingPrince { get; set; }
        public float SalePrice { get; set; }
        public int BuyingCurrencyId { get; set; } //tl, euro, dollar vb.
        public int SaleCurrencyId { get; set; } //tl, euro
        public int PaperWeight { get; set; }
        public bool Status { get; set; }

        public int CurrencyId { get; set; }
    }
}
