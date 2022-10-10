using RabbitMQ.Client;
using System;


namespace Essa.Framework.Mensageria
{
    public class ConexaoMensageria : IDisposable
    {
        private ConnectionFactory _factory;
        public IConnection Conexao { get; private set; }


        public ConexaoMensageria(string hostname, string userName, string password, string virtualHost = null
            , int consumerDispatchConcurrency = 1)
        {
            _factory = new ConnectionFactory()
            {
                HostName = hostname,
                UserName = userName,
                Password = password,
                VirtualHost = virtualHost,

                ConsumerDispatchConcurrency = consumerDispatchConcurrency
            };

            Conexao = _factory.CreateConnection();
        }
        public ConexaoMensageria(Uri url
            , int consumerDispatchConcurrency = 1) 
            : this(url.Authority, url.UserInfo.Split(':')[0], url.UserInfo.Split(':')[1], url.LocalPath.Replace("/", ""), consumerDispatchConcurrency)
        {
        }

        public ConexaoMensageria(string stringconexao
            , int consumerDispatchConcurrency = 1) : this(new Uri(stringconexao), consumerDispatchConcurrency)
        {
        }

        public void Dispose()
        {
            Conexao.Dispose();
        }
    }
}
