namespace SENAR.Framework.Web.Helpers.DataTables
{
    using global::DataTables.AspNet.Core;
    using System.Collections.Generic;
    using System.Linq;

    public static class DataTablesExtensionsV2
    {


        public static DataTablesReturnBuilder<T> ToDataTables<T>(this IQueryable<T> valor, IDataTablesRequest request)
        {
            return new DataTablesReturnBuilder<T>(valor, request);
        }

        public static DataTablesReturnBuilder<T> ToDataTables<T>(this IList<T> valor, IDataTablesRequest request)
        {
            return new DataTablesReturnBuilder<T>(valor.AsQueryable(), request);
        }
    }


}
