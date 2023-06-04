using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Business.Abstract;
using StockApp.Entity;
using StockApp.UI.Models.StockUnit;

namespace StockApp.UI.Controllers
{
    public class StockUnitController : Controller
    {
        private IStockUnitService _stockUnitService;
        private IStockTypeService _stockTypeService;
        private IQuantityUnitService _quantityUnitService;
        private ICurrencyService _currencyService;

        public StockUnitController(
            IStockUnitService stockUnitService, 
            IStockTypeService stockTypeService, 
            IQuantityUnitService quantityUnitService,
            ICurrencyService currencyService)
        {
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;   
            _quantityUnitService = quantityUnitService;
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {
            ListViewModel model = new ListViewModel();

            model.StockUnits = _stockUnitService.GetStockUnitDetailList();
            model.StockTypeSelectList = GetStockTypeSelectList();
            model.QuantityUnitSelectList = GetQuantityUnitSelectList();
            model.CurrencySelectList = GetCurrencySelectList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ListViewModel model)
        {
            StockApp.Entity.StockUnit record = new StockApp.Entity.StockUnit();

            //buraya daha önce eklenip eklenmediği kontrolü gelecek.
            var search = _stockUnitService.GetList().Where(x => x.UnitCode == model.StockUnitData.UnitCode).FirstOrDefault();
            if (search == null)
            {
                record.UnitCode = model.StockUnitData.UnitCode;
                record.StockTypeId = model.StockUnitData.StockTypeId;
                record.QuantityUnitId = model.StockUnitData.QuantityUnitId;
                record.Description = model.StockUnitData.Description;
                record.BuyingPrince = model.StockUnitData.BuyingPrince;
                record.BuyingCurrencyId = model.StockUnitData.BuyingCurrencyId;
                record.SalePrice = model.StockUnitData.SalePrice;
                record.SaleCurrencyId = model.StockUnitData.SaleCurrencyId;
                record.PaperWeight = model.StockUnitData.PaperWeight;
                record.Status = model.StockUnitData.Status;
                record.CurrencyId = 1;

                _stockUnitService.Add(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Error";
                    TempData["Message_Detail"] = "Stok Birimi eklenemedi!";
                }
                else
                {
                    TempData["Message"] = "Success";
                    TempData["Message_Detail"] = "Stok Birimi başarıyla eklendi!";
                }
            }
            else
            {
                TempData["Message"] = "Error";
                TempData["Message_Detail"] = "Stok Birim Kodu daha önce eklenmiştir!";
            }
            return Redirect("~/StockUnit");
        }
        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            StockApp.Entity.StockUnit stockUnit = _stockUnitService.GetById(id);
            StockApp.Entity.StockUnit model = new StockApp.Entity.StockUnit();

            if (stockUnit != null)
            {
                model.Id = stockUnit.Id;
                model.UnitCode = stockUnit.UnitCode;
                model.StockTypeId = stockUnit.StockTypeId;
                model.QuantityUnitId = stockUnit.QuantityUnitId;
                model.Description = stockUnit.Description;
                model.BuyingPrince = stockUnit.BuyingPrince;
                model.BuyingCurrencyId = stockUnit.BuyingCurrencyId;
                model.SalePrice = stockUnit.SalePrice;
                model.SaleCurrencyId=stockUnit.SaleCurrencyId;
                model.PaperWeight = stockUnit.PaperWeight;
                model.Status=stockUnit.Status;
            }
            else
            {
                TempData["Message"] = "Error";
                TempData["Message_Detail"] = "Stok Birimi bulunamadı!";
            }
            return Json(model);
        }
        [HttpPost]
        public IActionResult Update(ListViewModel model)
        {
            StockApp.Entity.StockUnit record = _stockUnitService.GetById(model.StockUnitData.Id);

            if (record != null)
            {
                record.UnitCode = model.StockUnitData.UnitCode;
                record.StockTypeId = model.StockUnitData.StockTypeId;
                record.QuantityUnitId = model.StockUnitData.QuantityUnitId;
                record.Description = model.StockUnitData.Description;
                record.BuyingPrince = model.StockUnitData.BuyingPrince;
                record.SalePrice = model.StockUnitData.SalePrice;
                record.BuyingCurrencyId = model.StockUnitData.BuyingCurrencyId;
                record.SaleCurrencyId = model.StockUnitData.SaleCurrencyId;
                record.PaperWeight=model.StockUnitData.PaperWeight;
                record.Status = model.StockUnitData.Status;
                record.CurrencyId = 1;

                _stockUnitService.Update(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Error";
                    TempData["Message_Detail"] = "Stok Birimi güncellenemedi!";
                }
                else
                {
                    TempData["Message"] = "Success";
                    TempData["Message_Detail"] = "Stok Birimi başarıyla güncellendi!";
                }
            }
            return Redirect("~/StockUnit");
        }

        private List<SelectListItem> GetCurrencySelectList()
        {
            return _currencyService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }

        private List<SelectListItem> GetQuantityUnitSelectList()
        {
            return _quantityUnitService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }

        private List<SelectListItem> GetStockTypeSelectList()
        {
            return _stockTypeService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }
    }
}
