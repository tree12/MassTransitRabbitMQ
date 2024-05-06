using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Producer.Data;
using Producer.Dtos;
using Producer.RabbitMQ;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMessageProducer _messagePublisher;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(IPublishEndpoint publishEndpoint, IMessageProducer messagePublisher)
        {
            _publishEndpoint = publishEndpoint;
            _messagePublisher = messagePublisher;
        }

        [HttpPost("RabbitMQCreateOrder")]
        public async Task<IActionResult> RabbitMQCreateOrder(OrderDto orderDto)
        {
            Order order = new()
            {
                Id = orderDto.Id,
                ProductName = orderDto.ProductName,
                Price = orderDto.Price,
                Quantity = orderDto.Quantity
            };

            _messagePublisher.SendMessage(order);

            return Ok(new { id = order.Id });
        }
        [HttpPost("MassTransitCreateOrder")]
        public async Task<IActionResult> MassTransitCreateOrder(OrderDto orderDto)
        {
            await _publishEndpoint.Publish<Order>(new
            {
                orderDto.Id,
                orderDto.ProductName,
                orderDto.Quantity,
                orderDto.Price
            });
            return Ok(new { id = orderDto.Id });
        }
    }
}
