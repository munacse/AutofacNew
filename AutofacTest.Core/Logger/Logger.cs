using AutofacTest.Core.Infrastructure;
using Serilog.Context;
using System;
using SeriLogger = Serilog.Core.Logger;

namespace AutofacTest.Core.Logger
{
    public class Logger : ILogger
    {
        private SeriLogger _logger;

        public Logger(SeriLogger logger)
        {
            this._logger = logger;
        }

        public void ConfigureLogger(string logFilePath)
        {
            var configuration = new SeriLoggerConfiguration();
            this._logger = configuration.ConfigureLogger(logFilePath);
        }

        public void Debug(string message, params object[] args)
        {
            this._logger.Debug(message, args);
        }

        public void Info(string message, params object[] args)
        {
            this._logger.Information(message, args);
        }

        public void Warn(string message, params object[] args)
        {
            this._logger.Warning(message, args);
        }

        public void Error(string message, params object[] args)
        {
            this._logger.Error(message, args);
        }

        public void Error(Exception e, string message, params object[] args)
        {
            this._logger.Error(e, message, args);
        }

        public void Fatal(string message, params object[] args)
        {
            this._logger.Fatal(message, args);
        }

        public void Fatal(Exception e, string message, params object[] args)
        {
            this._logger.Fatal(e, message, args);
        }

        public IDisposable WithProperty(string name, object value)
        {
            return LogContext.PushProperty(name, value);
        }
    }
}
