using Microsoft.AspNetCore.Mvc.Rendering;

namespace StockApp.UI.Models.Stock
{
    public class ListViewModel
    {
        public List<StockApp.Data.Models.Stock.StockDetail> Stocks { get; set; }
        public StockApp.Entity.Stock Stock { get; set; }

        public List<SelectListItem> StockClassSelectList { get; set; }
        public List<SelectListItem> StockTypeSelectList { get; set; }
        public List<SelectListItem> StockUnitSelectList { get; set; }
    }
}
