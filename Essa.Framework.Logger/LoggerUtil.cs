namespace Essa.Framework.Logger
{
    using Serilog;
    using Serilog.Events;
    using System;
    using System.IO;


    public class LoggerUtil
    {
        public Serilog.Core.Logger Log { get; set; }

        private LoggerConfiguration _loggerConfiguration;
        private readonly string _nomePrograma;

        public LoggerUtil(string nomePrograma)
        {
            _loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Sistema", nomePrograma)
                .WriteTo.Console();
            
            _nomePrograma = nomePrograma;
        }


        public void LogTxt(string diretoriolog = "")
        {
            string arquivolog = diretoriolog;

#if DEBUG
            arquivolog = Path.Combine(arquivolog, "DEBUG");
#endif

            _loggerConfiguration
                .WriteTo.File(Path.Combine(arquivolog, $"log_{_nomePrograma}_.txt"), rollingInterval: RollingInterval.Day)
                ;
        }



        public void LogMongoDb()
        {
            _loggerConfiguration
                .WriteTo.MongoDB("mongodb://localhost/logs")
                ;
        }



        public void LogMySql(string connectionString)
        {
            _loggerConfiguration
               .WriteTo.MySQL(connectionString, tableName: "log");
        }



        public IDisposable BeginGuid()
        {
            return Serilog.Context.LogContext.PushProperty("Transaction", Guid.NewGuid());
        }





        public Serilog.Core.Logger Ativar()
        {
            return _loggerConfiguration.CreateLogger();
        }


    }
}
