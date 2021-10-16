using RabbitMQ.Client;
using System;


namespace Essa.Framework.Mensageria
{
    public class ConexaoMensageria : IDisposable
    {
        private ConnectionFactory _factory;
        public IConnection Conexao { get; private set; }


        public ConexaoMensageria(string hostname, string userName, string password, string virtualHost = null)
        {
            _factory = new ConnectionFactory() { HostName = hostname, UserName = userName, Password = password, VirtualHost = virtualHost };

            Conexao = _factory.CreateConnection();
        }

        public ConexaoMensageria(string stringconexao)
        {
            var url = new Uri(stringconexao);

            _factory = new ConnectionFactory() { HostName = url.Authority, UserName = url.UserInfo.Split(':')[0], Password = url.UserInfo.Split(':')[1], VirtualHost = url.LocalPath.Replace("/", "") };

            Conexao = _factory.CreateConnection();
        }

        public void Dispose()
        {
            Conexao.Dispose();
        }
    }
}
