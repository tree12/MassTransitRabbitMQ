using MassTransit;
using Consummer;
var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("purchase-create-event", e => {
        e.Consumer<PurchaseCreatedConsummer>();
    });
});
await busControl.StartAsync(new CancellationToken());
try
{
    Console.WriteLine("Press enter to exite");
    await Task.Run(() => Console.ReadLine());
}
finally { 
    await busControl.StartAsync(); 
}
