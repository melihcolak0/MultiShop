using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces.OrderDetailInterfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repositories.OrderDetailRepositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderContext _context;

        public OrderDetailRepository(OrderContext context)
        {
            _context = context;
        }

        public Task<List<OrderDetail>> GetOrderDetailsByOrderId(int id)
        {
            return _context.Set<OrderDetail>()
                .Where(od => od.OrderId == id)
                .ToListAsync();
        }
    }
}
