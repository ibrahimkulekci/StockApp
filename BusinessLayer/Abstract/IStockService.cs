using StockApp.Data.Models.Stock;
using StockApp.Data.Models.StockUnit;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Abstract
{
    public interface IStockService
    {
        void Add(Stock stock);
        void Delete(Stock stock);
        void Update(Stock stock);
        List<Stock> GetList();
        Stock GetById(int id);

        List<StockDetail> GetStockDetailList();
    }
}
