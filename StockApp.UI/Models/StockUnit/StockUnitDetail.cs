namespace StockApp.UI.Models.StockUnit
{
    public class StockUnitDetail:StockApp.Entity.StockUnit
    {
        public string StockTypeName { get; set; }
        public string QuantityUnitName { get; set; }
        public string BuyingCurrencySymbol { get; set; }
        public string SaleCurrencySymbol { get; set; }
    }
}
