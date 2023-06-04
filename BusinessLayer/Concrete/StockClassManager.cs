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
    public class StockClassManager : IStockClassService
    {
        private IStockClassDal _stockClassDal;

        public StockClassManager(IStockClassDal stockClassDal)
        {
            _stockClassDal = stockClassDal;
        }

        public void Add(StockClass param)
        {
            _stockClassDal.Insert(param);
        }

        public void Delete(StockClass param)
        {
            _stockClassDal.Delete(param);
        }

        public StockClass GetById(int id)
        {
            return _stockClassDal.GetById(id);
        }

        public List<StockClass> GetList()
        {
            return _stockClassDal.GetListAll();
        }

        public void Update(StockClass param)
        {
            _stockClassDal.Update(param);
        }
    }
}
