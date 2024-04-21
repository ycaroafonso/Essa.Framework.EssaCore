namespace Essa.Framework.WebCore.JqGrid
{
    using System;


    public static class JqGridColumnUtil
    {

        public enum FormatterUtilEnum
        {
            MesAno
        }

        public static JqGridColumn SetFormatter(this JqGridColumn obj, FormatterUtilEnum valor)
        {
            switch (valor)
            {
                case FormatterUtilEnum.MesAno:
                    return obj.SetFormatter("function (cellValue, options, rowObject) { return cellValue == null ? '' : (cellValue.toString().substr(4,2) + '/' + cellValue.toString().substr(0,4)); }");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}
