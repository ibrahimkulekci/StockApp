using StockApp.Business.Abstract;
using StockApp.Data.Abstract;
using StockApp.Data.Models.StockUnit;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Concrete
{
    public class StockUnitManager : IStockUnitService
    {
        private IStockUnitDal _stockUnitDal;

        public StockUnitManager(IStockUnitDal stockUnitDal)
        {
            _stockUnitDal = stockUnitDal;
        }

        public void Add(StockUnit stockUnit)
        {
            _stockUnitDal.Insert(stockUnit);
        }

        public void Delete(StockUnit stockUnit)
        {
            _stockUnitDal.Delete(stockUnit);
        }

        public StockUnit GetById(int id)
        {
            return _stockUnitDal.GetById(id);
        }

        public List<StockUnit> GetList()
        {
            return _stockUnitDal.GetListAll().OrderByDescending(x=>x.Id).ToList();
        }

        public List<StockUnitDetail> GetStockUnitDetailList()
        {
            return _stockUnitDal.GetJoinAll().OrderByDescending(x=>x.Id).ToList();
        }

        public void Update(StockUnit stockUnit)
        {
            _stockUnitDal.Update(stockUnit);
        }
    }
}
