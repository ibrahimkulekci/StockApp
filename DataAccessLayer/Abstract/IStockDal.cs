using StockApp.Data.Models.Stock;
using StockApp.Data.Models.StockUnit;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Data.Abstract
{
    public interface IStockDal:IGenericDal<Stock>
    {
        public List<StockDetail> GetJoinAll();
    }
}
