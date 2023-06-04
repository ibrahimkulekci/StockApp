using StockApp.Data.Models.StockUnit;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Abstract
{
    public interface IStockUnitService
    {
        void Add(StockUnit stockUnit);
        void Delete(StockUnit stockUnit);
        void Update(StockUnit stockUnit);
        List<StockUnit> GetList();
        StockUnit GetById(int id);

        List<StockUnitDetail> GetStockUnitDetailList();
    }
}
