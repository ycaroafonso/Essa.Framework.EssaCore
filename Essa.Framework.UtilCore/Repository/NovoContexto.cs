using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Essa.Framework.Util.Repository
{
    public class NovoContexto<TContext> where TContext : DbContext
    {
        public TContext Contexto { get; private set; }

        public TContext Conectar(string connetionString = null)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<TContext>(o => o.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            return serviceCollection.BuildServiceProvider().GetService<TContext>();
        }

    }
}
