using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Abstract
{
    public interface ICurrencyService
    {
        void Add(Currency param);
        void Delete(Currency param);
        void Update(Currency param);
        List<Currency> GetList();
        Currency GetById(int id);
    }
}
