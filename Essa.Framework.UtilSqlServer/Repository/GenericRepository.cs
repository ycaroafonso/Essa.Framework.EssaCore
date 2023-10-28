using Essa.Framework.UtilSqlServer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Essa.Framework.Util.Repository
{


    public class GenericRepository<T, TContext> : GenericRepository<TContext>, IGenericRepository<T>
        where T : class
        where TContext : DbContext
    {
        public GenericRepository(TContext contexto) : base(contexto) { }



        public virtual IQueryable<T> ObterTodos()
        {
            return Contexto.Set<T>();
        }



        public IGenericRepository<T> Incluir(T instancia)
        {
            Contexto.Set<T>().Add(instancia);

            return this;
        }
        public async Task<IGenericRepository<T>> IncluirAsync(T instancia)
        {
            await Contexto.Set<T>().AddAsync(instancia);

            return this;
        }
        public IGenericRepository<T> Incluir(ICollection<T> instancia)
        {
            Contexto.Set<T>().AddRange(instancia);

            return this;
        }



        public virtual IGenericRepository<T> Alterar(T instancia)
        {
            Anexar(instancia, EntityState.Modified);

            return this;
        }



        public virtual IGenericRepository<T> Excluir(T instancia)
        {
            Anexar(instancia, EntityState.Deleted);
            return this;
        }
        public virtual IGenericRepository<T> Excluir(List<T> instancia)
        {
            foreach (var item in instancia)
            {
                Anexar(instancia, EntityState.Deleted);
            }

            return this;
        }
        public virtual IEnumerable<T> Excluir(Expression<Func<T, bool>> func)
        {
            Contexto.Set<T>().RemoveRange(ObterTodos().Where(func));

            return null;
        }




        public virtual IGenericRepository<T> Anexar(T instancia)
        {
            Contexto.Set<T>().Attach(instancia);

            return this;
        }

        public virtual IGenericRepository<T> Anexar(ICollection<T> lista, EntityState state)
        {
            foreach (var item in lista)
                Anexar(item, state);

            return this;
        }




    }



}
