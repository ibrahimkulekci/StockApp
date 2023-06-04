using Microsoft.AspNetCore.Mvc;
using StockApp.Business.Abstract;
using StockApp.Entity;
using StockApp.UI.Models.StockType;

namespace StockApp.UI.Controllers
{
    public class StockTypeController : Controller
    {
        private IStockTypeService _stockTypeService;

        public StockTypeController(IStockTypeService stockTypeService)
        {
            _stockTypeService = stockTypeService;
        }

        public IActionResult Index()
        {
            StockApp.UI.Models.StockType.ListViewModel model = new ListViewModel();


            model.StockType = _stockTypeService.GetList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ListViewModel model)
        {
            StockApp.Entity.StockType record = new StockApp.Entity.StockType();

            if (model.Name == null)
            {
                TempData["Message"] = "Error";
                TempData["Message_Detail"] = "Lütfen Stok Türü adını boş bırakmayınız!";
            }
            else
            {
                //buraya daha önce eklenip eklenmediği kontrolü gelecek.
                var search = _stockTypeService.GetList().Where(x => x.Name.ToLower().Contains(model.Name.ToLower())).FirstOrDefault();

                if (search == null)
                {
                    record.Name = model.Name;
                    record.Status = model.Status;

                    _stockTypeService.StockTypeAdd(record);

                    if (record.Id == null)
                    {
                        TempData["Message"] = "Error";
                        TempData["Message_Detail"] = "Stok Türü eklenemedi!";
                    }
                    else
                    {
                        TempData["Message"] = "Success";
                        TempData["Message_Detail"] = "Stok Türü başarıyla eklendi!";
                    }
                }
                else
                {
                    TempData["Message"] = "Error";
                    TempData["Message_Detail"] = "Stok Türü daha önce eklenmiştir!";
                }                
            }
            return Redirect("~/StockType");
        }
        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            var stockType=_stockTypeService.GetById(id);
            ListViewModel model = new ListViewModel();

            if(stockType != null)
            {
                model.Id= stockType.Id;
                model.Name = stockType.Name;
                model.Status = stockType.Status;
            }
            else
            {
                TempData["Message"] = "Error";
                TempData["Message_Detail"] = "Stok Türü bulunamadı!";
            }
            return Json(model);
        }
        [HttpPost]
        public IActionResult Update(ListViewModel model)
        {
            StockApp.Entity.StockType record = _stockTypeService.GetById(model.Id);
            if (record != null)
            {
                record.Name = model.Name;
                record.Status = model.Status;

                _stockTypeService.StockTypeUpdate(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Error";
                    TempData["Message_Detail"] = "Stok Türü güncellenemedi!";
                }
                else
                {
                    TempData["Message"] = "Success";
                    TempData["Message_Detail"] = "Stok Türü başarıyla güncellendi!";
                }
            }
            return Redirect("~/StockType");
        }
    }
}
