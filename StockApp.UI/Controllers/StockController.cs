using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockApp.Business.Abstract;
using StockApp.UI.Models.Stock;

namespace StockApp.UI.Controllers
{
    public class StockController : Controller
    {
        private IStockService _stockService;
        private IStockClassService _stockClassService;
        private IStockTypeService _stockTypeService;
        private IStockUnitService _stockUnitService;

        public StockController(
            IStockService stockService, 
            IStockClassService stockClassService,
            IStockUnitService stockUnitService,
            IStockTypeService stockTypeService)
        {
            _stockService = stockService;
            _stockClassService = stockClassService;
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
        }

        public IActionResult Index()
        {
            StockApp.UI.Models.Stock.ListViewModel model = new Models.Stock.ListViewModel();

            model.Stocks = _stockService.GetStockDetailList();
            model.StockClassSelectList = GetStockClassSelectList();
            model.StockTypeSelectList = GetStockTypeSelectList();
            model.StockUnitSelectList = GetStockUnitSelectList();


            return View(model);
        }
        [HttpGet]
        public IActionResult DataTable()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DataTableJson()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;



                string strSql = @"select * from dbo.Stocks s
                                where
	                                1=1 ";

                //filtering
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    strSql += @" and s.UnitCode like '%"+ searchValue +"%' ";
                //}
                if (!string.IsNullOrEmpty(searchValue))
                {
                    strSql += @" and (s.UnitCode like '%"+ searchValue + "%' or s.Name like '"+ searchValue + "') ";
                }

                //sorting
                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
                {
                    strSql = strSql + " order by s."+ sortColumn + " " + sortColumnDirection;
                }

                //paging
                strSql += " offset "+skip.ToString()+" rows fetch next "+pageSize.ToString()+" rows only ";


                var stockdata = _stockService.GetList();

                if(!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    //stockdata = stockdata.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    //stockdata = stockdata.Where(x => x.Name.Contains(searchValue));
                    stockdata = stockdata.Where(x => x.Name.ToLower().Contains(searchValue.ToLower()) 
                    || x.Id.ToString().Contains(searchValue))
                        .ToList();
                }
                recordsTotal= stockdata.Count();
                var data = stockdata.Skip(skip).Take(pageSize).ToList();
                var jsondata=new {draw=draw,recordsFiltered=recordsTotal,recordsTotal=recordsTotal,data=data};
                return Ok(jsondata);
            }
            catch (Exception e)
            {
                return View();
                throw;
            }
        }
        [HttpPost]
        public IActionResult Add(ListViewModel model)
        {
            StockApp.Entity.Stock record = new Entity.Stock();

            record.UnitCode = 0; //bunu StockUnits table'dan çektiğimiz için iptal ettik.
            record.StockClassId = model.Stock.StockClassId;
            record.StockTypeId=model.Stock.StockTypeId;
            record.Name = null; //bunu StockUnits table'dan çektiğimiz için iptal ettik.
            record.Quantity = model.Stock.Quantity;
            record.Shelf= model.Stock.Shelf;
            record.Cupboard= model.Stock.Cupboard;
            record.CriticQantity= model.Stock.CriticQantity;
            record.Status = model.Stock.Status;
            record.StockUnitId= model.Stock.StockUnitId;

            _stockService.Add(record);

            if (record.Id == null)
            {
                TempData["Message"] = "Error";
                TempData["Message_Detail"] = "Stok eklenemedi!";
            }
            else
            {
                TempData["Message"] = "Success";
                TempData["Message_Detail"] = "Stok başarıyla eklendi!";
            }

            return Redirect("~/Stock");

        }
        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            StockApp.Entity.Stock model = _stockService.GetById(id);

            if(model != null)
            {
                return Json(model);
            }
            else
            {
                TempData["Message"] = "Error";
                TempData["Message_Detail"] = "Stok Birimi bulunamadı!";
                return Json(TempData);
            }            
        }
        [HttpPost]
        public IActionResult Update(ListViewModel model)
        {
            StockApp.Entity.Stock record = _stockService.GetById(model.Stock.Id);
            if (record != null)
            {
                record.UnitCode = 0; //bunu StockUnits table'dan çektiğimiz için iptal ettik.
                record.StockClassId = model.Stock.StockClassId;
                record.StockTypeId = model.Stock.StockTypeId;
                record.Name = null; //bunu StockUnits table'dan çektiğimiz için iptal ettik.
                record.Quantity = model.Stock.Quantity;
                record.Shelf = model.Stock.Shelf;
                record.Cupboard = model.Stock.Cupboard;
                record.CriticQantity = model.Stock.CriticQantity;
                record.Status = model.Stock.Status;
                record.StockUnitId = model.Stock.StockUnitId;

                _stockService.Update(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Error";
                    TempData["Message_Detail"] = "Stok güncellenemedi!";
                }
                else
                {
                    TempData["Message"] = "Success";
                    TempData["Message_Detail"] = "Stok başarıyla güncellendi!";
                }
            }
            return Redirect("~/Stock");
        }

        private List<SelectListItem> GetStockTypeSelectList()
        {
            return _stockTypeService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }

        private List<SelectListItem> GetStockUnitSelectList()
        {
            return _stockUnitService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Description) }).ToList();
        }

        private List<SelectListItem> GetStockClassSelectList()
        {
            return _stockClassService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }
    }
}
