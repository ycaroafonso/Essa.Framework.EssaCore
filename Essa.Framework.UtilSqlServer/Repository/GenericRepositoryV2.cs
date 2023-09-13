using Essa.Framework.Util.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Essa.Framework.UtilSqlServer.Repository
{
    public class GenericRepository<TContext> : IGenericTransactionRepository, IGenericRepository
        where TContext : DbContext
    {


        protected TContext Contexto { get; private set; }

        public GenericRepository(TContext contexto)
        {
            Contexto = contexto;
        }





        public IList<T> SqlQuery<T>(string sql, params object[] parametros) where T : class
        {
            return Contexto.Set<T>().FromSqlRaw(sql, parametros).ToList();
        }

        public IQueryable<T> SqlQueryInterpolated<T>(FormattableString sql) where T : class
        {
            return Contexto.Set<T>().FromSqlInterpolated(sql);
        }

        public int ExecuteSqlCommand(string sql, params object[] parametros)
        {
            return Contexto.Database.ExecuteSqlRaw(sql, parametros);
        }
        public int ExecuteSqlCommandInterpolated(FormattableString sql)
        {
            return Contexto.Database.ExecuteSqlInterpolated(sql);
        }
        public Task<int> ExecuteSqlCommandInterpolatedAsync(FormattableString sql)
        {
            return Contexto.Database.ExecuteSqlInterpolatedAsync(sql);
        }
        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parametros)
        {
            return await Contexto.Database.ExecuteSqlRawAsync(sql, parametros);
        }





        public IDbContextTransaction BeginTransaction()
        {
            return Contexto.Database.BeginTransaction();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Contexto.Database.BeginTransactionAsync();
        }







        public virtual void Alterar<T>(T instancia) where T : class
        {
            Anexar(instancia, EntityState.Modified);
        }

        public void Anexar<T>(T instancia) where T : class
        {
            Contexto.Set<T>().Attach(instancia);
        }

        public void Anexar<T>(T instancia, EntityState state) where T : class
        {
            Anexar(instancia);
            Contexto.Entry(instancia).State = state;
        }

        public void Anexar<T>(ICollection<T> lista, EntityState state) where T : class
        {
            foreach (var item in lista)
                Anexar(item, state);

        }

        public void Excluir<T>(List<T> instancia) where T : class
        {
            foreach (var item in instancia)
            {
                Anexar(item, EntityState.Deleted);
            }
        }

        public void Excluir<T>(T instancia) where T : class
        {
            Anexar(instancia, EntityState.Deleted);
        }





        public void Incluir<T>(ICollection<T> instancia) where T : class
        {
            Contexto.Set<T>().AddRange(instancia);
        }
        public void Incluir<T>(List<T> instancia) where T : class
        {
            Contexto.Set<T>().AddRange(instancia);
        }

        public void Incluir<T>(T instancia) where T : class
        {
            Contexto.Set<T>().Add(instancia);
        }
        public async Task IncluirAsync<T>(T instancia) where T : class
        {
            await Contexto.Set<T>().AddAsync(instancia);
        }





        public int Salvar()
        {
            return Contexto.SaveChanges();
        }

        public Task<int> SalvarAsync()
        {
            return Contexto.SaveChangesAsync();
        }




        public void Dispose()
        {
            Contexto.Dispose();
        }

        public IQueryable<T> ObterTodos<T>() where T : class
        {
            return Contexto.Set<T>();
        }

    }

}
