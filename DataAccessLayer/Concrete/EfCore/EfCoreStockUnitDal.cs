using StockApp.Data.Abstract;
using StockApp.Data.Models.StockUnit;
using StockApp.Data.Repository;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Data.Concrete.EfCore
{
    public class EfCoreStockUnitDal : GenericRepository<StockUnit>, IStockUnitDal
    {
        public List<StockUnitDetail> GetJoinAll()
        {
            List<StockUnitDetail> resultList = new List<StockUnitDetail>();

            using (StockAppDbContext c=new StockAppDbContext())
            {
                var record = from su in c.StockUnits
                             join st in c.StockTypes on su.StockTypeId equals st.Id
                             join qu in c.QuantityUnits on su.QuantityUnitId equals qu.Id
                             join cu in c.Currencies on su.BuyingCurrencyId equals cu.Id
                             join cur in c.Currencies on su.SaleCurrencyId equals cur.Id
                             select new StockUnitDetail()
                             {
                                 BuyingCurrencyId = su.BuyingCurrencyId,
                                 BuyingCurrencySymbol = cu.Symbol,
                                 BuyingPrince = su.BuyingPrince,
                                 Description = su.Description,
                                 Id = su.Id,
                                 PaperWeight = su.PaperWeight,
                                 QuantityUnitId = su.QuantityUnitId,
                                 QuantityUnitName = qu.Name,
                                 SaleCurrencyId = su.SaleCurrencyId,
                                 SaleCurrencySymbol = cur.Symbol,
                                 SalePrice = su.SalePrice,
                                 Status = su.Status,
                                 StockTypeId = su.StockTypeId,
                                 StockTypeName = st.Name,
                                 UnitCode = su.UnitCode,
                             };

                resultList=record.ToList();
            }
            return resultList;
        }
    }
}
