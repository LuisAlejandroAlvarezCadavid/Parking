using Microsoft.Extensions.Logging;
using Parking.Domain.Entities;
using Parking.Domain.Ports;
using Parking.Infrastructure.Exceptions;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System.Text;
using System.Text.Json;

namespace Parking.Infrastructure.Adapters.Brocker
{
    [Repository]
    public class BrockerSenderRepository : IBrockerSenderRepository
    {
        readonly ILogger<BrockerSenderRepository> _logger;
        public BrockerSenderRepository(ILogger<BrockerSenderRepository> logger)
        {
            _logger = logger;
        }
        public bool ConfigAndSendMessageToBrocker(Logs logsMessage)
        {
            try
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var message = JsonSerializer.Serialize(logsMessage);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                return true;
            }
            catch (RabbitMQClientException exp)
            {
                _logger.LogError(exp, exp.InnerException?.Message);
                throw new BrockerException("Se ha presentado un error con el cliente de RabbitMq");
            }

        }
    }
}
