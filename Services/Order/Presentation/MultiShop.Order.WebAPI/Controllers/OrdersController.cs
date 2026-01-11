using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;
using System.Threading.Tasks;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderList()
        {
            var values = await _mediator.Send(new GetOrderQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var value = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yeni sipariş başarıyla eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            await _mediator.Send(new RemoveOrderCommand(id));
            return Ok("Sipariş başarıyla silindi!");
        }

        [HttpPost("CreateOrderReturnId")]
        public async Task<IActionResult> CreateOrderReturnId(CreateOrderReturnIdCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetOrdersListByUserId")]
        public async Task<IActionResult> GetOrdersListByUserId(string id)
        {
            var values = await _mediator.Send(new GetOrderByUserIdQuery(id));
            return Ok(values);
        }
    }
}
