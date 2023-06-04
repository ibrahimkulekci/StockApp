using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Abstract
{
    public interface IQuantityUnitService
    {
        void Add(QuantityUnit param);
        void Delete(QuantityUnit param);
        void Update(QuantityUnit param);
        List<QuantityUnit> GetList();
        QuantityUnit GetById(int id);
    }
}
