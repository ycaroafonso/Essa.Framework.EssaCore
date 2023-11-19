using RabbitMQ.Client;
using System;
using System.Collections.Generic;

namespace Essa.Framework.Mensageria
{
    public interface ICadastrarMensageria : IDisposable
    {
        IModel Canal { get; }
        string Exchange { get; set; }
        uint MessageCount { get; }
        string Queue { get; set; }
        string RoutingKey { get; set; }

        void ConfirmarRecebimento(ulong deliveryTag);
        void CriarBasicProperties(string replyTo);
        void CriarBind(string exchange, string routingKey);
        void CriarCanal();
        void CriarFila(string queue, bool autoDelete = false, IDictionary<string, object> arguments = null);
        void CriarFila(string queue, bool durable, bool autoDelete = false, IDictionary<string, object> arguments = null);
        void Dispose();
        void Publicar(byte[] body);
        void Publicar<T>(T body);
        void Receber(Action<ulong, byte[]> received);
        void Receber<T>(Action<ulong, T> received);
        void TravarFinalizacao();
    }
}