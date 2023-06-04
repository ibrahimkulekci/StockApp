using StockApp.Business.Abstract;
using StockApp.Data.Abstract;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Concrete
{
    public class StockTypeManager : IStockTypeService
    {
        private IStockTypeDal _StockTypeDal;

        public StockTypeManager(IStockTypeDal stockTypeDal)
        {
            _StockTypeDal = stockTypeDal;
        }

        public StockType GetById(int id)
        {
            return _StockTypeDal.GetById(id);
        }

        public List<StockType> GetList()
        {
            return _StockTypeDal.GetListAll().OrderByDescending(x=>x.Id).ToList();
        }

        public void StockTypeAdd(StockType stockType)
        {
            _StockTypeDal.Insert(stockType);
        }

        public void StockTypeDelete(StockType stockType)
        {
            _StockTypeDal.Delete(stockType);
        }

        public void StockTypeUpdate(StockType stockType)
        {
            _StockTypeDal.Update(stockType);
        }
    }
}
