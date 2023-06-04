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
    public class CurrencyManager : ICurrencyService
    {
        private ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }

        public void Add(Currency param)
        {
            _currencyDal.Insert(param);
        }

        public void Delete(Currency param)
        {
            _currencyDal.Delete(param);
        }

        public Currency GetById(int id)
        {
            return _currencyDal.GetById(id);
        }

        public List<Currency> GetList()
        {
            return _currencyDal.GetListAll();
        }

        public void Update(Currency param)
        {
            _currencyDal.Update(param);
        }
    }
}
