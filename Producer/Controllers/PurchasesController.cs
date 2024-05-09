using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Producer.Data;
using Producer.Dtos;
using Producer.RabbitMQ;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchasesController : ControllerBase
    {
        private readonly IMessageProducer _messagePublisher;
        private readonly IPublishEndpoint _publishEndpoint;

        public PurchasesController(IPublishEndpoint publishEndpoint, IMessageProducer messagePublisher)
        {
            _publishEndpoint = publishEndpoint;
            _messagePublisher = messagePublisher;
        }

        [HttpPost("RabbitMQCreatePurchase")]
        public async Task<IActionResult> RabbitMQCreatePurchase(PurchaseDto purchaseDto)
        {
            Purchase purchase = new()
            {
                Id = purchaseDto.Id,
                ProductName = purchaseDto.ProductName,
                Price = purchaseDto.Price,
                Quantity = purchaseDto.Quantity
            };

            _messagePublisher.SendMessage(purchase);

            return Ok(new { id = purchase.Id });
        }
        [HttpPost("MassTransitCreatePurchase")]
        public async Task<IActionResult> MassTransitCreatePurchase(PurchaseDto purchaseDto)
        {
            await _publishEndpoint.Publish<Purchase>(new
            {
                purchaseDto.Id,
                purchaseDto.ProductName,
                purchaseDto.Quantity,
                purchaseDto.Price
            });
            return Ok(new { id = purchaseDto.Id });
        }
    }
}
