# rabbitmq-webapi
Sample application for understanding the use of a Message Broker using RabbitMQ

In order to run and witnes the project working it needs to run RabbbitMQ with docker by the following command:

```
docker run -d --hostname my-rabbitmq-server --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

The reference for this project could be found on the following [Tutorial](https://code-maze.com/aspnetcore-rabbitmq/)
