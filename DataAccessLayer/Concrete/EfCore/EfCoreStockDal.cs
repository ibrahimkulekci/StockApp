using StockApp.Data.Abstract;
using StockApp.Data.Models.Stock;
using StockApp.Data.Repository;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Data.Concrete.EfCore
{
    public class EfCoreStockDal : GenericRepository<Stock>, IStockDal
    {
        public List<StockDetail> GetJoinAll()
        {
            List<StockDetail> resultList= new List<StockDetail>();
            using (StockAppDbContext c = new StockAppDbContext())
            {
                var record = from s in c.Stocks
                             join sc in c.StockClasses on s.StockClassId equals sc.Id
                             join st in c.StockTypes on s.StockTypeId equals st.Id
                             join su in c.StockUnits on s.StockUnitId equals su.Id
                             join qu in c.QuantityUnits on su.QuantityUnitId equals qu.Id
                             select new StockDetail()
                             {
                                 Id = s.Id,
                                 StockClassName = sc.Name,
                                 StockClassId = s.StockClassId,
                                 StockUnitId = s.StockUnitId,
                                 StockUnitCode = su.UnitCode,
                                 StockUnitDescription = su.Description,
                                 StockTypeName = st.Name,
                                 StockTypeId=s.StockTypeId,
                                 Quantity = s.Quantity,
                                 CriticQantity = s.CriticQantity,
                                 QuantityUnitName = qu.Name,
                                 Cupboard=s.Cupboard,
                                 Shelf=s.Shelf, 
                                 Status= s.Status,
                             };
                resultList = record.ToList();
            }
            return resultList;
        }
    }
}
