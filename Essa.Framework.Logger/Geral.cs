namespace Essa.Framework.Logger
{
    using Serilog;
    using Serilog.Events;
    using System;
    using System.IO;


    public static class Geral
    {
        public static Serilog.Core.Logger Log(string nomePrograma = "", string diretoriolog = "", string connectionStringMySql = "")
        {
            string arquivolog = diretoriolog;

            switch (diretoriolog)
            {
                case "mongodb":
                    return LogMongoDb(nomePrograma);
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

        [Obsolete]
        public static Serilog.Core.Logger LogMongoDb(string nomePrograma, string diretoriolog)
        {
            return LogMongoDb(nomePrograma);
        }

        public static Serilog.Core.Logger LogMongoDb(string nomePrograma = "")
        {
            return new LoggerConfiguration()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
.Enrich.FromLogContext()
.Enrich.WithProperty("Sistema", nomePrograma)
.WriteTo.Console()
.WriteTo.MongoDB("mongodb://localhost/logs")
.CreateLogger();
        }



        public static Serilog.Core.Logger LogMySql(string nomePrograma, string connectionString)
        {
            return new LoggerConfiguration()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
.Enrich.FromLogContext()
.Enrich.WithProperty("Sistema", nomePrograma)
.WriteTo.Console()
.WriteTo.MySQL(connectionString, tableName: "log")
.CreateLogger();
        }


    }
}
