using MassTransit;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Consummer
{
    public class OrderCreatedConsummer : IConsumer<IOrderCreated>
    {
        public async Task Consume(ConsumeContext<IOrderCreated> context)
        {
            var jsonMessage = JsonSerializer.Serialize(context.Message);
            Console.WriteLine($"Received message: {jsonMessage}");
            await Task.CompletedTask;
        }
    }
}
