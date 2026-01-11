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
    public class CargoCustomerManager : GenericManager<CargoCustomer>, ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal) : base(cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public CargoCustomer TGetCargoCustomerByUserId(string userId)
        {
            return _cargoCustomerDal.GetCargoCustomerByUserId(userId);
        }
    }
}
