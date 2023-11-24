using RabbitMQ.Client;
using System;

namespace Essa.Framework.Mensageria
{
    public interface IConexaoMensageria : IDisposable
    {
        IConnection Conexao { get; }

        void Conectar();
        void Dispose();
        ICadastrarMensageria NovaFila();
    }
}