using StockApp.Business.Abstract;
using StockApp.Data.Abstract;
using StockApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Business.Concrete
{
    public class QuantityUnitManager : IQuantityUnitService
    {
        private IQuantityUnitDal _quantityUnitDal;

        public QuantityUnitManager(IQuantityUnitDal quantityUnitDal)
        {
            _quantityUnitDal = quantityUnitDal;
        }

        public QuantityUnit GetById(int id)
        {
            return _quantityUnitDal.GetById(id);
        }

        public List<QuantityUnit> GetList()
        {
            return _quantityUnitDal.GetListAll();
        }

        public void Add(QuantityUnit param)
        {
            _quantityUnitDal.Insert(param);
        }

        public void Delete(QuantityUnit param)
        {
            _quantityUnitDal.Delete(param);
        }

        public void Update(QuantityUnit param)
        {
            _quantityUnitDal.Update(param);
        }
    }
}
