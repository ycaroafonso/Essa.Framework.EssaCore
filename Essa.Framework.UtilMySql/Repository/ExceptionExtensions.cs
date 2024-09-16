using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Essa.Framework.UtilMySql.Repository;

public static class ExceptionExtensions
{
    public static string ToMensagemErro(this DbUpdateException ex, int nivel = 0)
    {
        var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

        try
        {
            foreach (var result in ex.Entries)
            {
                builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
            }
        }
        catch (Exception e)
        {
            builder.Append("Error parsing DbUpdateException: " + e.ToString());
        }

        return builder.ToString();
    }
}
