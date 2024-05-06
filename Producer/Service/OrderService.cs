using MassTransit;
using Producer.Data;
using Producer.Dtos;
using Producer.RabbitMQ;
using SharedModels;

namespace Producer.Service
{
    public class OrderService: IOrderService
    {
        private readonly IMessageProducer _messageProducer;
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderService(IMessageProducer messageProducer, IPublishEndpoint publishEndpoint)
        {
            _messageProducer = messageProducer;
            _publishEndpoint = publishEndpoint;
        }
        public async Task SaveOrder(OrderDto orderDto) {
            //var order = await Save(orderDto);
            //if (order is not null)
            //    _messageProducer.SendMessage(order);
            //if (orderDto is not null)
            //    _messageProducer.SendMessage(orderDto);
            if (orderDto is not null)
                await _publishEndpoint.Publish<IOrderCreated>(new
                {
                    orderDto.Id,
                    orderDto.ProductName,
                    orderDto.Quantity,
                    orderDto.Price
                });
        }
        //private async Task<Order> Save(OrderDto orderDto) { }
    }
}
