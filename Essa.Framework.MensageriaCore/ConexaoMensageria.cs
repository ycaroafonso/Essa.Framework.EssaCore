using RabbitMQ.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Essa.Framework.Mensageria;

public class ConexaoMensageria : IConexaoMensageria
{
    private ConnectionFactory factory;

    public ConexaoMensageria(ConnectionFactory factory)
    {
        this.factory = factory;
    }

    public IConnection Conexao { get; private set; }


    public ConexaoMensageria(string hostname, string userName, string password, string virtualHost = null
        , ushort consumerDispatchConcurrency = 1)
    {
        factory = new ConnectionFactory()
        {
            HostName = hostname,
            UserName = userName,
            Password = password,

            ConsumerDispatchConcurrency = consumerDispatchConcurrency,
        };

        if (!string.IsNullOrEmpty(virtualHost))
            factory.VirtualHost = virtualHost;
    }


    public ConexaoMensageria(Uri url
        , ushort consumerDispatchConcurrency = 1)
        : this(url.Authority, url.UserInfo.Split(':')[0], url.UserInfo.Split(':')[1], url.LocalPath.Replace("/", ""), consumerDispatchConcurrency)
    {
    }

    public ConexaoMensageria(string stringconexao
        , ushort consumerDispatchConcurrency = 1) : this(new Uri(stringconexao), consumerDispatchConcurrency)
    {
    }


    public async Task Conectar()
    {
        Conexao = await factory.CreateConnectionAsync();
    }


    public string VirtualHost { get => factory.VirtualHost; }

    public HttpClient ConectarHttp()
    {
        using var client = new HttpClient { BaseAddress = factory.Uri };
        var creds = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{factory.UserName}:{factory.Password}"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", creds);

        return client;
    }

    public async Task<ICadastrarMensageria> NovaFila()
    {
        if (Conexao == null) await Conectar();
        return new CadastrarMensageria(this);
    }


    public void Dispose()
    {
        if (Conexao != null)
            Conexao.Dispose();
    }
}