namespace Essa.Framework.WebCore.Helpers.JqGrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class JqGridReturnBuilder<T>
    {
        private int _qtdeRegistro { get; set; }
        public JqGridReturn Retorna { get; set; }
        private GridSettings _GridSettings;
        private IQueryable<T> _lista;


        public JqGridReturnBuilder(IQueryable<T> lista, GridSettings gridSettings)
        {
            _GridSettings = gridSettings;
            _lista = lista;


            //if (gridSettings.Where != null)
            //    foreach (var item in gridSettings.Where.rules.Where(c => c.data != ""))
            //        switch (item.op)
            //        {
            //            case "eq":
            //                _lista = _lista.Where(string.Concat(item.field, " = " + ProcessaValor(item.data)));
            //                break;
            //            case "cn":
            //                _lista = _lista.Where(string.Concat(item.field, ".contains(\"", item.data, "\")"));
            //                break;
            //            case "bool":
            //                _lista = _lista.Where(string.Concat(item.field, " = ", item.data));
            //                break;
            //            default:
            //                _lista = _lista.Where(string.Concat(item.field, " ", item.op, " ", ProcessaValor(item.data)));
            //                break;
            //        }

            _qtdeRegistro = _lista.Count();
            Retorna = new JqGridReturn
            {
                records = _qtdeRegistro,
                page = gridSettings.PageIndex,
                total = (int)Math.Ceiling(_qtdeRegistro / (decimal)gridSettings.PageSize),
            };
        }

        public JqGridReturnBuilder(List<T> lista, GridSettings gridSettings)
        {
            _qtdeRegistro = lista.Count();

            Retorna = new JqGridReturn
            {
                records = _qtdeRegistro,
                page = gridSettings.PageIndex,
                total = (int)Math.Ceiling(_qtdeRegistro / (decimal)gridSettings.PageSize),
                rows = lista
            };
        }

        public JqGridReturn ToReturn()
        {
            if (!string.IsNullOrEmpty(_GridSettings.SortColumn))
            {
                Retorna.rows = _lista//.OrderBy(_GridSettings.SortColumn + " " + _GridSettings.SortOrder)
                    .Skip((_GridSettings.PageIndex - 1) * _GridSettings.PageSize)
                    .Take(_GridSettings.PageSize)
                    .ToList();
            }
            else
            {
                Retorna.rows = _lista.Skip((_GridSettings.PageIndex - 1) * _GridSettings.PageSize)
                    .Take(_GridSettings.PageSize)
                    .ToList();
            }

            return Retorna;
        }

        public JqGridReturn ToReturn<TResult>(Func<T, TResult> select)
        {
            if (!string.IsNullOrEmpty(_GridSettings.SortColumn))
            {
                Retorna.rows = _lista//.OrderBy(_GridSettings.SortColumn + " " + _GridSettings.SortOrder)
                    .Skip((_GridSettings.PageIndex - 1) * _GridSettings.PageSize)
                    .Take(_GridSettings.PageSize)
                    .ToList().Select(select);
            }
            else
            {
                Retorna.rows = _lista.Skip((_GridSettings.PageIndex - 1) * _GridSettings.PageSize)
                    .Take(_GridSettings.PageSize)
                    .ToList().Select(select);
            }

            return Retorna;
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
