using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Abstract
{
    public interface IStockTypeService
    {
        void StockTypeAdd(StockType stockType);
        void StockTypeDelete(StockType stockType);
        void StockTypeUpdate(StockType stockType);
        List<StockType> GetList();
        StockType GetById(int id);
    }
}
