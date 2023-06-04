

namespace StockApp.UI.Models.StockType
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }

        public IEnumerable<StockApp.Entity.StockType> StockType { get; set; }
    }
}
