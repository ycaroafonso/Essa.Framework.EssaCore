using RabbitMQ.Client;
using System;
using System.Threading.Tasks;

namespace Essa.Framework.Mensageria
{
    public interface IConexaoMensageria : IDisposable
    {
        IConnection Conexao { get; }

        Task Conectar();
        ICadastrarMensageria NovaFila();
    }
}