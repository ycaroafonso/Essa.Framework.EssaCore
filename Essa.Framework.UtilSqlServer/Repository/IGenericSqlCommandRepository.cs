namespace Essa.Framework.Util.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IGenericSqlCommandRepository
    {
        int ExecuteSqlCommand(string sql, params object[] parametros);
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parametros);
        int ExecuteSqlCommandInterpolated(FormattableString sql);
        Task<int> ExecuteSqlCommandInterpolatedAsync(FormattableString sql);
        IList<T> SqlQuery<T>(string sql, params object[] parametros) where T : class;
        IQueryable<T> SqlQueryInterpolated<T>(FormattableString sql) where T : class;
    }
}
