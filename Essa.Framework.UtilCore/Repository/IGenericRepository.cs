﻿namespace Essa.Framework.UtilCore.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public interface IGenericBaseRepository : IDisposable
    {
        //DbRawSqlQuery<T> SqlQuery<T>(string sql, params object[] parametros);
        //int ExecuteSqlCommand(string sql, params object[] parametros);
        IDbContextTransaction BeginTransaction();
    }


    public interface IGenericReadRepository
    {
        IQueryable<T> ObterTodos<T>() where T : class;
    }

    public interface IGenericReadRepository<T>
        where T : class
    {
        IQueryable<T> ObterTodos();
    }



    public interface IGenericSalvarRepository
    {
        int Salvar();
    }





    public interface IGenericIncluirRepository<T> : IGenericSalvarRepository
        where T : class
    {
        IGenericRepository<T> Incluir(T instancia);
        IGenericRepository<T> Incluir(ICollection<T> instancia);
    }
    public interface IGenericIncluirRepository
    {
        void Incluir<T>(T instancia) where T : class;
        void Incluir<T>(ICollection<T> instancia) where T : class;
    }






    public interface IGenericAlterarRepository<T> : IGenericSalvarRepository
        where T : class
    {
        IGenericRepository<T> Alterar(T instancia);
    }

    public interface IGenericAlterarRepository
    {
        void Alterar<T>(T instancia) where T : class;
    }






    public interface IGenericAnexarRepository<T> : IGenericSalvarRepository
        where T : class
    {
        IGenericRepository<T> Anexar(ICollection<T> lista, EntityState state);

        IGenericRepository<T> Anexar(T instancia);

        IGenericRepository<T> Anexar(T instancia, EntityState state);
    }

    public interface IGenericAnexarRepository
    {
        void Anexar<T>(ICollection<T> lista, EntityState state) where T : class;

        void Anexar<T>(T instancia) where T : class;

        void Anexar<T>(T instancia, EntityState state) where T : class;
    }






    public interface IGenericExcluirRepository<T> : IGenericSalvarRepository
        where T : class
    {
        IGenericRepository<T> Excluir(T instancia);
        IGenericRepository<T> Excluir(List<T> instancia);
    }

    public interface IGenericExcluirRepository
    {
        void Excluir<T>(T instancia) where T : class;
        void Excluir<T>(List<T> instancia) where T : class;
    }






    public interface IGenericRepository<T> : IGenericReadRepository<T>, IGenericIncluirRepository<T>, IGenericAlterarRepository<T>, IGenericExcluirRepository<T>, IGenericSalvarRepository
        where T : class
    {
    }

    public interface IGenericRepository : IGenericReadRepository, IGenericIncluirRepository, IGenericAlterarRepository, IGenericExcluirRepository, IGenericSalvarRepository
    {
    }
}
