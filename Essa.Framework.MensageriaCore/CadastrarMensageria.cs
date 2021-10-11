using Essa.Framework.Util.Extensions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;


namespace Essa.Framework.Mensageria
{
    public partial class CadastrarMensageria : IDisposable
    {
        private IModel _channel;
        string _queue;
        string _routingKey;
        string _exchange = "";

        ConexaoMensageria _conexaoMensageria;

        public CadastrarMensageria(ConexaoMensageria conexaoMensageria)
        {
            _conexaoMensageria = conexaoMensageria;
        }


        public CadastrarMensageria(string stringconexao)
        {
            Conecta(stringconexao);
        }

        public void Conecta(string hostname, string userName, string password, string virtualHost = null)
        {
            _conexaoMensageria = new ConexaoMensageria(hostname, userName, password, virtualHost);
        }

        public void Conecta(string conexao)
        {
            _conexaoMensageria = new ConexaoMensageria(conexao);
        }


        public void CriarFila(string queue, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            _queue = queue;
            _routingKey = queue;

            CriarFila(durable: true,
                     autoDelete: autoDelete,
                     arguments: arguments);
        }
        public void CriarFila(string queue, bool durable, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            _queue = queue;
            _routingKey = queue;

            CriarFila(durable: durable,
                     autoDelete: autoDelete,
                     arguments: arguments);
        }
        private void CriarFila(bool durable, bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            _channel = _conexaoMensageria.Conexao.CreateModel();
            _channel.QueueDeclare(queue: _queue,
                     durable: durable,
                     exclusive: false,
                     autoDelete: autoDelete,
                     arguments: arguments);
        }


        public void CriarBind(string exchange, string routingKey)
        {
            _routingKey = routingKey;
            _exchange = exchange;

            _channel.QueueBind(queue: _queue,
                     exchange: _exchange,
                     routingKey: _routingKey);
        }





        public void Receber(Action<ulong, byte[]> received)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                received(ea.DeliveryTag, ea.Body.ToArray());
            };

            _channel.BasicConsume(queue: _queue,
                                 autoAck: false,
                                 consumer: consumer);
        }


        public void Receber<T>(Action<ulong, T> received)
        {
            Receber((t, c) => received(t, Encoding.UTF8.GetString(c, 0, c.Length).ToOjectFromJson<T>()));
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
            _channel.BasicPublish(exchange: _exchange,
                            routingKey: _routingKey,
                            body: body);
        }







        public void Dispose()
        {
            _conexaoMensageria.Dispose();
            _channel.Dispose();
        }






















        [Obsolete]
        public enum LocalRabbitMqEnum
        {
            Localhost,
            CloudAmqp,
            Customizado
        }
        [Obsolete]
        public CadastrarMensageria(string queue, string stringconexao)
        {
            _queue = queue;
            Conecta(stringconexao);
        }

        [Obsolete]
        public CadastrarMensageria(string queue, LocalRabbitMqEnum localRabbitMq)// = LocalRabbitMqEnum.Localhost
        {
            switch (localRabbitMq)
            {
                case LocalRabbitMqEnum.Localhost:
                    Conecta("localhost", "guest", "guest");
                    break;
                default:
                    break;
            }

            _queue = queue;
            _routingKey = queue;
        }

        [Obsolete]
        public void CriarFila(bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            CriarFila(_queue, autoDelete, arguments);
        }
    }
}