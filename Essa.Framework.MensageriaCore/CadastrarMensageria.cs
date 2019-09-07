namespace Essa.Framework.MensageriaCore
{
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using System;

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

            _channel.QueueDeclare(queue: queue,
                     durable: true,
                     exclusive: false,
                     autoDelete: autoDelete,
                     arguments: null);
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
            _channel.BasicPublish(exchange: "",
                            routingKey: _queue,
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
