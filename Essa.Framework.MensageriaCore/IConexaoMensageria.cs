using RabbitMQ.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Essa.Framework.Mensageria;

public interface IConexaoMensageria : IDisposable
{
    IConnection Conexao { get; }
    string VirtualHost { get; }

    Task Conectar();
    HttpClient ConectarHttp();
    Task<ICadastrarMensageria> NovaFila();
}