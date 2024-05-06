# MassTransitRabbitMQ
MassTransit and RabbitMQ with .net core 8.0

## Getting Started
This project is just my curious to know what is MassTransit and RabbitMQ. 
### Prerequisites
1. Visual studio 2022 with .net core 8.0
2. Docker Desktop

Before to run the project make sure you have installed and run docker already, and then run below command to get RabbitMQ image from docker hub as
   ```sh
   docker run -d --hostname my-rabbitmq-server --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
   ```
After install image to docker, browse to http://localhost:15672
- username and password are same as <b>guest</b>
  
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


Thanks to
reference
- https://masstransit.io/documentation/concepts
- https://code-maze.com/aspnetcore-rabbitmq/
- https://code-maze.com/masstransit-rabbitmq-aspnetcore/


