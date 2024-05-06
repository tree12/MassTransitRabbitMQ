# MassTransitRabbitMQ
MassTransit and RabbitMQ with .net core 8.0

<b>Consummer</b>
-	This project receive message from queue which broadcast from MassTransit.
  
<b>Producer</b>
-	This project is web api contain 2 methods as
    -	RabbitMQCreateOrder => this method send message directly to queue without MassTransit.
    -	MassTransitCreateOrder => this method send message directly to MassTransit for broadcasting.

<b>SharedModels</b>
- This project contain interface
  
<b>Subscriber</b>
- This project receive message from queue without MassTransit


This project is just my curious thi know what is MassTransit and RabbitMQ. Therefore thanks to
reference
- https://masstransit.io/documentation/concepts
- https://code-maze.com/aspnetcore-rabbitmq/
- https://code-maze.com/masstransit-rabbitmq-aspnetcore/


