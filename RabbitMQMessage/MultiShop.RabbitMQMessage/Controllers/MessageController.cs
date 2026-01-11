using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private static string _message;

        [HttpGet]
        public IActionResult ReadMessage()
        {

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var result = channel.BasicGet("Kuyruk2", autoAck: true);

            if (result == null)
                return NoContent();

            var message = Encoding.UTF8.GetString(result.Body.ToArray());
            return Ok(message);

            //var factory = new ConnectionFactory();

            //factory.HostName = "localhost";

            //var connection = factory.CreateConnection();

            //var channel = connection.CreateModel();

            //var consumer = new EventingBasicConsumer(channel);

            //consumer.Received += (model, x) =>
            //{
            //    var byteMessage = x.Body.ToArray();
            //    _message = Encoding.UTF8.GetString(byteMessage);
            //};

            //channel.BasicConsume(queue: "Kuyruk2", autoAck: false, consumer: consumer);

            //if (string.IsNullOrEmpty(_message))
            //    return NoContent();
            //else
            //    return Ok(_message);
        }

        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2", false, false, arguments: null);

            var messageContent = "Merhaba bugün hava çok sıcak!";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContent);

            return Ok("Mesajınız alınmıştır!");
        }
    }
}
