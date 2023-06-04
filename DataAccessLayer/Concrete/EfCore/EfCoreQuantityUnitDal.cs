using StockApp.Data.Abstract;
using StockApp.Data.Repository;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Data.Concrete.EfCore
{
    public class EfCoreQuantityUnitDal:GenericRepository<QuantityUnit>, IQuantityUnitDal
    {
    }
}
