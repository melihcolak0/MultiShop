using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : GenericManager<CargoOperation>, ICargoOperationService
    {
        public CargoOperationManager(ICargoOperationDal cargoOperationDal) : base(cargoOperationDal)
        {
        }
    }
}
