using StockApp.Business.Abstract;
using StockApp.Data.Abstract;
using StockApp.Data.Models.Stock;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Concrete
{
    public class StockManager : IStockService
    {
        private IStockDal _stockDal;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public void Add(Stock stock)
        {
            _stockDal.Insert(stock);
        }

        public void Delete(Stock stock)
        {
            _stockDal.Delete(stock);
        }

        public Stock GetById(int id)
        {
            return _stockDal.GetById(id);
        }

        public List<Stock> GetList()
        {
            return _stockDal.GetListAll();
        }

        public List<StockDetail> GetStockDetailList()
        {
            return _stockDal.GetJoinAll();
        }

        public void Update(Stock stock)
        {
            _stockDal.Update(stock);
        }
    }
}
