﻿namespace Essa.Framework.Logger
{
    using Serilog;
    using Serilog.Events;
    using System;
    using System.IO;


    public static class LogV2
    {
        public static void Information(string messageTemplate)
        {
            Log.Information(messageTemplate);
        }
    }

    public class LoggerUtil
    {
        public Serilog.Core.Logger Log { get; set; }

        private LoggerConfiguration _loggerConfiguration;
        private readonly string _nomePrograma;


        [Obsolete]
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
        public LoggerUtil(LoggerConfiguration loggerConfiguration)
        {
            _loggerConfiguration = loggerConfiguration;
        }
        public LoggerUtil()
        {
        }






        [Obsolete]
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




        [Obsolete]
        public void LogMySql(string connectionString)
        {
            _loggerConfiguration
               .WriteTo.MySQL(connectionString, tableName: "portallogservico");
        }



        public IDisposable BeginGuid()
        {
            return Serilog.Context.LogContext.PushProperty("Transaction", Guid.NewGuid());
        }





        [Obsolete]
        public Serilog.Core.Logger Ativar()
        {
            return _loggerConfiguration.CreateLogger();
        }


    }
}
