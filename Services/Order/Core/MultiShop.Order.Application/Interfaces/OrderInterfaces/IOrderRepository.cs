using MultiShop.Order;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces.OrderInterfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderReturnIdAsync(Domain.Entities.Order order);
        Task<List<Domain.Entities.Order>> GetOrdersListByUserIdAsync(string id);
    }
}
