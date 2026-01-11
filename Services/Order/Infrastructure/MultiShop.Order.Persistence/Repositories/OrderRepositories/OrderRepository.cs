using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces.OrderInterfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrderReturnIdAsync(Domain.Entities.Order order)
        {
            await _context.Set<Domain.Entities.Order>().AddAsync(order);
            await _context.SaveChangesAsync();

            return order.OrderId;
        }

        public async Task<List<Domain.Entities.Order>> GetOrdersListByUserIdAsync(string id)
        {
            return await _context.Set<Domain.Entities.Order>()
                .Where(o => o.UserId == id)
                .ToListAsync();
        }
    }
}
