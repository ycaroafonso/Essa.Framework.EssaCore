namespace Essa.Framework.Logger
{
    using Serilog;
    using Serilog.Events;


    public static class Geral
    {
        public static Serilog.Core.Logger Log(string nomePrograma = "", string diretoriolog = "")
        {
            string arquivolog = diretoriolog;
#if DEBUG
            arquivolog += @"DEBUG\";
#endif

            return new LoggerConfiguration()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
.Enrich.FromLogContext()
.Enrich.WithProperty("Sistema", nomePrograma)
.WriteTo.Console()
.WriteTo.File($"{arquivolog}log_{nomePrograma}_.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();
        }


        public static Serilog.Core.Logger LogMongoDb(string nomePrograma = "", string diretoriolog = "")
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
    }
}
