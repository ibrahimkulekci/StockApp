using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Abstract
{
    public interface IStockClassService
    {
        void Add(StockClass param);
        void Delete(StockClass param);
        void Update(StockClass param);
        List<StockClass> GetList();
        StockClass GetById(int id);
    }
}
