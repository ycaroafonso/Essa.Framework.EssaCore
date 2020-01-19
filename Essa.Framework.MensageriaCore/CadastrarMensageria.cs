namespace Essa.Framework.MensageriaCore
{
    using Essa.Framework.UtilCore.Extensions;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using System;
    using System.Collections.Generic;



    public class CadastrarMensageria : IDisposable
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        string _queue;

        public CadastrarMensageria(string queue, bool autoDelete = false)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _queue = queue;
        }


        public void CriarFila(bool autoDelete = false, IDictionary<string, object> arguments = null)
        {
            _channel.QueueDeclare(queue: _queue,
                     durable: true,
                     exclusive: false,
                     autoDelete: autoDelete,
                     arguments: arguments);
        }



        private ulong CodigoRecebimento;

        public void Receber(Action<byte[]> received)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                CodigoRecebimento = ea.DeliveryTag;

                received(ea.Body);
            };

            _channel.BasicConsume(queue: _queue,
                                 autoAck: false,
                                 consumer: consumer);
        }







        public void ConfirmarRecebimento()
        {
            _channel.BasicAck(CodigoRecebimento, false);
        }















        public void Publicar(byte[] body)
        {
            Publicar(_queue, body);
        }


        public void Publicar<T>(T body)
        {
            Publicar(body.ToJson().ToByteArray());
        }

        public void Publicar(string routingKey, byte[] body)
        {
            _channel.BasicPublish(exchange: "",
                            routingKey: routingKey,
                            basicProperties: null,
                            body: body);
        }







        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}
