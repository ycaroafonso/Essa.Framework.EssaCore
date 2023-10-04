namespace Essa.Framework.Util.Repository
{
    using Microsoft.EntityFrameworkCore.Storage;
    using System;

    public interface IGenericTransactionRepository : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
