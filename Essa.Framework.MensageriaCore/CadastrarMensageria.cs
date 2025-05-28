using Essa.Framework.Util.Extensions;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Essa.Framework.Mensageria;

internal class CadastrarMensageria(IConexaoMensageria conexaoMensageria) : IDisposable, ICadastrarMensageria
{
    private IChannel channel;
    public string Queue { get; set; }
    public string RoutingKey { get; set; }
    public string Exchange { get; set; } = "";
    public IChannel Canal { get => channel; }

    public async Task CriarFila(string queue, bool autoDelete = false, IDictionary<string, object> arguments = null)
    {
        Queue = queue;

        await CriarFila(durable: true,
                       autoDelete: autoDelete,
                       arguments: arguments);
    }
    public async Task CriarFila(string queue, bool durable, bool autoDelete = false, IDictionary<string, object> arguments = null)
    {
        Queue = queue;

        await CriarFila(durable: durable,
                         autoDelete: autoDelete,
                         arguments: arguments);
    }


    public async Task CriarCanal()
    {
        if (channel == null)
        {
            channel = await conexaoMensageria.Conexao.CreateChannelAsync();
            await channel.BasicQosAsync(0, PrefetchCount, false); // Permite até 10 mensagens por consumidor

        }
    }

    private async Task CriarFila(bool durable, bool autoDelete = false, IDictionary<string, object> arguments = null)
    {
        await CriarCanal();
        await channel.QueueDeclareAsync(queue: Queue,
                         durable: durable,
                         exclusive: false,
                         autoDelete: autoDelete,
                         arguments: arguments);
    }


    public async Task CriarBind(string exchange, string routingKey)
    {
        RoutingKey = routingKey;
        Exchange = exchange;

        await channel.QueueBindAsync(queue: Queue,
                         exchange: Exchange,
                         routingKey: RoutingKey ?? Queue);
    }


    public async Task CriarExchange(string exchange, string type, IDictionary<string, object> args)
    {
        await channel.ExchangeDeclareAsync(exchange, type, durable: true, arguments: args);
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

    public Task<uint> MessageCount
    {
        get
        {
            return channel.MessageCountAsync(Queue);
        }
    }

    public ushort PrefetchCount { get; set; }

    public async Task<string> Receber(Func<ulong, byte[], Task> received)
    {
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            await received(ea.DeliveryTag, ea.Body.ToArray());
        };

        return await channel.BasicConsumeAsync(queue: Queue,
                                     autoAck: false,
                                     consumer: consumer);

    }


    public async Task Receber<T>(Func<ulong, T, Task> received, JsonSerializerSettings settings = null)
    {
        await Receber(async (t, c) => await received(t, Encoding.UTF8.GetString(c, 0, c.Length).ToObjectFromJson<T>(settings)));
    }





    public async Task ConfirmarRecebimento(ulong deliveryTag)
    {
        await channel.BasicAckAsync(deliveryTag, false);
    }















    public async Task Publicar<T>(T body)
    {
        await Publicar(body.ToJson().ToByteArray());
    }
    public async Task Publicar(byte[] body)
    {
        //await _channel.BasicPublishAsync(Exchange, RoutingKey ?? Queue, false, _basicProperties, body);

        await channel.BasicPublishAsync(exchange: Exchange, routingKey: RoutingKey ?? Queue,
                mandatory: false
                //, basicProperties: _basicProperties
                , body: body);
    }

    private IReadOnlyBasicProperties _basicProperties;

    //public void CriarBasicProperties(string? replyTo = null)
    //{
    //    _basicProperties = new BasicProperties();
    //    _basicProperties.ReplyTo = replyTo;
    //}

    //public void Delay(TimeSpan delay)
    //{
    //    _basicProperties.Headers ??= new Dictionary<string, object>();
    //    _basicProperties.Headers.Add("x-delay", (int)delay.TotalMilliseconds);
    //}




    public void Dispose()
    {
        //channel.Dispose();
    }

    public async Task BasicReject(ulong tag)
    {
        await channel.BasicRejectAsync(tag, true);
    }









    public async Task<long> TotalMensagensNaFila()
    {
        using var client = conexaoMensageria.ConectarHttp();

        var resp = await client.GetAsync($"/api/queues/{Uri.EscapeDataString(conexaoMensageria.VirtualHost)}/{Uri.EscapeDataString(Queue)}");
        if (!resp.IsSuccessStatusCode) return 0;

        using var doc = JsonDocument.Parse(await resp.Content.ReadAsStringAsync());
        var ready = doc.RootElement.GetProperty("messages_ready").GetInt64();
        var unacked = doc.RootElement.GetProperty("messages_unacknowledged").GetInt64();
        return ready + unacked;
    }

}