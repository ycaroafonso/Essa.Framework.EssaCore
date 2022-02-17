using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Essa.Framework.Web.Helpers.DataTables;
using Essa.Framework.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static Essa.Framework.Web.Helpers.DataTables.DataTablesUtil;

namespace Essa.Framework.Web.Helpers.DataTables
{
    public static class DataTablesUtil
    {
        public enum TipoFiltro
        {
            Contem,
            Igual,
            Customizado,

            MaiorOuIgual,
            MenorOuIgual
        }
    }

    public class DataTablesReturnBuilder<T>
    {
        private int _qtdeTotal;
        private IQueryable<T> _listaFiltrada;
        private readonly IDataTablesRequest _request;


        public DataTablesReturnBuilder(IQueryable<T> lista, IDataTablesRequest request)
        {

            _qtdeTotal = lista.Count();

            _listaFiltrada = lista;

            _request = request;
        }

        public DataTablesReturnBuilder<T> AddFiltro(Expression<Func<T, bool>> filtro)
        {
            _listaFiltrada = _listaFiltrada.Where(filtro);
            return this;
        }

        public IQueryable<T> RetornaConsulta()
        {
            return _listaFiltrada;
        }





        public DataTablesReturnBuilder<T> AddFiltro<TParam>(string nomeFiltro, Func<TParam, Expression<Func<T, bool>>> filtro)
        {
            if (_request.AdditionalParameters.ContainsKey(nomeFiltro))
            {
                var d = _request.Get<TParam>(nomeFiltro);
                var x = filtro(d);
                _listaFiltrada = _listaFiltrada.Where(x);
            }

            return this;
        }




        string Operador(TipoFiltro tipoFiltro)
        {
            switch (tipoFiltro)
            {
                case TipoFiltro.Igual:
                    return "=";
                case TipoFiltro.MaiorOuIgual:
                    return ">=";
                case TipoFiltro.MenorOuIgual:
                    return "<= ";
                default:
                    throw new Exception();
            }
        }


        public DataTablesJsonResult ToReturn<TResult>(Func<T, TResult> select, IDictionary<string, object> additionalParameters = null)
        {
            var qtdeFiltrado = _listaFiltrada.Count();

            var sortColumm = _request.Columns.FirstOrDefault(x => x.Sort != null);
            if (sortColumm != null)
            {
                if (sortColumm.Sort.Direction == SortDirection.Descending)
                    _listaFiltrada = _listaFiltrada.OrderBy(sortColumm.Name + " desc");
                else
                    _listaFiltrada = _listaFiltrada.OrderBy(sortColumm.Name);

                _listaFiltrada = _listaFiltrada.Skip(_request.Start);

                if (_request.Length > 0)
                    _listaFiltrada = _listaFiltrada.Take(_request.Length);
            }

            var listaFinal = _listaFiltrada.ToList().Select(select);

            var response = DataTablesResponse.Create(_request, _qtdeTotal, qtdeFiltrado, listaFinal, additionalParameters);
            return new DataTablesJsonResult(response);
        }


        private string ProcessaValor(string valor)
        {
            int n;
            if (valor.Contains("DateTime") || int.TryParse(valor, out n))
                return valor;
            else
                return "\"" + valor + "\"";
        }
    }
}
