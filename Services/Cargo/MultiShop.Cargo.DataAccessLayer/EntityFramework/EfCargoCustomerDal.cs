using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _context;

        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
            _context = context;
        }

        public CargoCustomer GetCargoCustomerByUserId(string userId)
        {
            return _context.CargoCustomers.FirstOrDefault(c => c.CargoUserId == userId);
        }
    }
}
