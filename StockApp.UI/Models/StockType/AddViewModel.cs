using System.ComponentModel.DataAnnotations;

namespace StockApp.UI.Models.StockType
{
    public class AddViewModel
    {
        [Required(ErrorMessage = "Lütfen Stok Türü adını boş gelmeyin!")]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
