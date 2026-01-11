using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Interfaces.OrderInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class CreateOrderReturnIdCommandHandler : IRequestHandler<CreateOrderReturnIdCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderReturnIdCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderReturnIdCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Entities.Order
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
                IsPaid = request.IsPaid
            };

            int orderId = await _orderRepository.CreateOrderReturnIdAsync(order);

            return orderId;
        }
    }
}
