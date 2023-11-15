using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Essa.Framework.Util.Extensions;
using System;
using System.Collections.Generic;
using System.Text;


namespace Essa.Framework.Mensageria
{
    public partial class CadastrarMensageria : IDisposable, ICadastrarMensageria
    {
        private IModel _channel;
        public string Queue { get; set; }
        public string RoutingKey { get; set; }
        public string Exchange { get; set; } = "";

        IConexaoMensageria _conexaoMensageria;

        public CadastrarMensageria(IConexaoMensageria conexaoMensageria)
        {
            _conexaoMensageria = conexaoMensageria;
        }


        public void CriarFila(string queue, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            Queue = queue;

            CriarFila(durable: true,
                     autoDelete: autoDelete,
                     arguments: arguments);
        }
        public void CriarFila(string queue, bool durable, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            Queue = queue;

            CriarFila(durable: durable,
                     autoDelete: autoDelete,
                     arguments: arguments);
        }


        public void CriarCanal()
        {
            if (_channel == null)
                _channel = _conexaoMensageria.Conexao.CreateModel();
        }
        public IModel Canal { get => _channel; }

        private void CriarFila(bool durable, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            CriarCanal();
            _channel.QueueDeclare(queue: Queue,
                     durable: durable,
                     exclusive: false,
                     autoDelete: autoDelete,
                     arguments: arguments);
        }


        public void CriarBind(string exchange, string routingKey)
        {
            RoutingKey = routingKey;
            Exchange = exchange;

            _channel.QueueBind(queue: Queue,
                     exchange: Exchange,
                     routingKey: RoutingKey ?? Queue);
        }





        public void TravarFinalizacao()
        {
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Mensageria em execução. Digite \"F\" para finalizar!");
            } while (Console.ReadKey().Key.ToString() != "F");

            Console.WriteLine("");
            Console.WriteLine("Mensageria finalizada");
        
        }

        public uint MessageCount { get => _channel.MessageCount(Queue); }










        public void Receber(Action<ulong, byte[]> received)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                received(ea.DeliveryTag, ea.Body.ToArray());
            };

            _channel.BasicConsume(queue: Queue,
                                 autoAck: false,
                                 consumer: consumer);
        }


        public void Receber<T>(Action<ulong, T> received)
        {
            Receber((t, c) => received(t, Encoding.UTF8.GetString(c, 0, c.Length).ToObjectFromJson<T>()));
        }





        public void ConfirmarRecebimento(ulong deliveryTag)
        {
            _channel.BasicAck(deliveryTag, false);
        }















        public void Publicar<T>(T body)
        {
            Publicar(body.ToJson().ToByteArray());
        }
        public void Publicar(byte[] body)
        {
            _channel.BasicPublish(exchange: Exchange,
                   routingKey: RoutingKey ?? Queue,
                   basicProperties: _basicProperties,
                   body: body);
        }


        IBasicProperties _basicProperties = null;

        public void CriarBasicProperties(string replyTo)
        {
            _basicProperties = _channel.CreateBasicProperties();
            _basicProperties.ReplyTo = replyTo;
        }





        public void Dispose()
        {
            _channel.Dispose();
        }





    }
}