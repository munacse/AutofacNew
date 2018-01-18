using Serilog;

namespace AutofacTest.Core.Logger
{
    public class SeriLoggerConfiguration
    {
        private const string MessageTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} " +
                                        "{MachineName}->{ProcessId}->{ThreadId} " +
                                        "[{Level}] " +
                                        "{Message}{NewLine}{Exception}";
        public Serilog.Core.Logger ConfigureLogger(string logFilePath)
        {
            var seriLogger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .WriteTo.RollingFile(logFilePath, outputTemplate: MessageTemplate)
                .WriteTo.Console(outputTemplate: MessageTemplate)
                .Enrich.FromLogContext()
                .CreateLogger();

            return seriLogger;
        }
    }
}
