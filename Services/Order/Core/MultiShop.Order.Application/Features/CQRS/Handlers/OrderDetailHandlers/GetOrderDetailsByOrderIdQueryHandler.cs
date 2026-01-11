using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Interfaces.OrderDetailInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailsByOrderIdQueryHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetOrderDetailsByOrderIdQueryHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<GetOrderDetailsByOrderIdQueryResult>> Handle(GetOrderDetailsByOrderIdQuery query)
        {
            var values = await _orderDetailRepository
                .GetOrderDetailsByOrderId(query.Id);

            return values.Select(value => new GetOrderDetailsByOrderIdQueryResult
            {
                OrderDetailId = value.OrderDetailId,
                OrderId = value.OrderId,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                Amount = value.Amount,
                TotalPrice = value.TotalPrice
            }).ToList();
        }
    }
}
