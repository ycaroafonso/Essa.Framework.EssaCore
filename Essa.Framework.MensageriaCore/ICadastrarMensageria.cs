using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Essa.Framework.Mensageria;

public interface ICadastrarMensageria : IDisposable
{
    string Exchange { get; set; }
    string Queue { get; set; }
    string RoutingKey { get; set; }
    IChannel Canal { get; }
    Task<uint> MessageCount { get; }
    ushort PrefetchCount { get; set; }

    Task BasicReject(ulong tag);
    Task ConfirmarRecebimento(ulong deliveryTag);
    Task CriarBind(string exchange, string routingKey);
    Task CriarCanal();
    Task CriarExchange(string exchange, string type, IDictionary<string, object> args);
    Task CriarFila(string queue, bool autoDelete = false, IDictionary<string, object> arguments = null);
    Task CriarFila(string queue, bool durable, bool autoDelete = false, IDictionary<string, object> arguments = null);
    Task Publicar<T>(T body);
    Task Publicar(byte[] body);
    Task<string> Receber(Func<ulong, byte[], Task> received);
    Task Receber<T>(Func<ulong, T, Task> received, JsonSerializerSettings settings = null);
    void TravarFinalizacao();
}