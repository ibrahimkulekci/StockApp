using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Entity;

namespace StockApp.UI.Models.StockUnit
{
    public class ListViewModel
    {
        public List<StockApp.Data.Models.StockUnit.StockUnitDetail> StockUnits { get; set; }
        public StockApp.Entity.StockUnit StockUnitData { get; set; }

        public List<SelectListItem> StockTypeSelectList { get; set; }
        public List<SelectListItem> QuantityUnitSelectList { get; set; }
        public List<SelectListItem> CurrencySelectList { get; set; }
    }
}
