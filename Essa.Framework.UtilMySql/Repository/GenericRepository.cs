using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Essa.Framework.Util.Repository;

public class GenericRepository<TContext> : IGenericBaseRepository, IGenericRepository
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

    public int ExecuteSqlCommand(string sql, params object[] parametros)
    {
        return Contexto.Database.ExecuteSqlRaw(sql, parametros);
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
    public virtual int Excluir<T>(Expression<Func<T, bool>> func) where T : class
    {
        return Contexto.Set<T>().Where(func).ExecuteDelete();
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
    public async Task<IGenericRepository> IncluirAsync<T>(T instancia) where T : class
    {
        await Contexto.Set<T>().AddAsync(instancia);

        return this;
    }

    public int Salvar()
    {
        return Contexto.SaveChanges();
    }




    public void Dispose()
    {
        Contexto.Dispose();
    }

    public IQueryable<T> ObterTodos<T>() where T : class
    {
        return Contexto.Set<T>();
    }

    public Task<int> SalvarAsync()
    {
        return Contexto.SaveChangesAsync();
    }
}


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

    public int Excluir(Expression<Func<T, bool>> func)
    {
        return Contexto.Set<T>().Where(func).ExecuteDelete();
    }
    public async Task<int> ExcluirAsync(Expression<Func<T, bool>> func)
    {
        return await Contexto.Set<T>().Where(func).ExecuteDeleteAsync();
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




    #region Plus


    public void AnexarAdded(T instancia)
    {
        Anexar(instancia, EntityState.Added);
    }

    public virtual IGenericRepository<T> AnexarAdded(ICollection<T> lista)
    {
        Anexar(lista, EntityState.Added);

        return this;
    }


    #endregion


}
