using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailsByOrderIdQuery
    {
        public int Id { get; set; }

        public GetOrderDetailsByOrderIdQuery(int id)
        {
            Id = id;
        }
    }
}
