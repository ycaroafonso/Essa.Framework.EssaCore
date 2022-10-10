namespace Essa.Framework.Logger
{
    using Serilog;
    using Serilog.Events;
    using System.IO;


    public static class Geral
    {
        public static Serilog.Core.Logger Log(string nomePrograma = "", string diretoriolog = "", string connectionStringMySql = "")
        {
            string arquivolog = diretoriolog;

            switch (diretoriolog)
            {
                case "mysql":
                    return LogMySql(nomePrograma, connectionStringMySql);
                default:

#if DEBUG
                    arquivolog = Path.Combine(arquivolog, "DEBUG");
#endif


                    return new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Sistema", nomePrograma)
        .WriteTo.Console()
        .WriteTo.File(Path.Combine(arquivolog, $"log_{nomePrograma}_.txt"), rollingInterval: RollingInterval.Day)
        .CreateLogger();
            }

        }



        public static Serilog.Core.Logger LogMySql(string nomePrograma, string connectionString)
        {
            return new LoggerConfiguration()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
.Enrich.FromLogContext()
.Enrich.WithProperty("Sistema", nomePrograma)
.WriteTo.Console()
.WriteTo.MySQL(connectionString, tableName: "portallogservico", tag: nomePrograma)
.CreateLogger();
        }


    }
}