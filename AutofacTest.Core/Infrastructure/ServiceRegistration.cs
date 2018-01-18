using Autofac;
using AutofacTest.Core.Logger;
using AutofacTest.Core.Services;
using Serilog;
using System.IO;
using Module = Autofac.Module;

namespace AutofacTest.Core.Infrastructure
{
    public class ServiceRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterService(builder);
            RegisterLogger(builder);
        }

        private void RegisterService(ContainerBuilder builder)
        {
            builder.RegisterType<SubstractService>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<AddService>().AsSelf().AsImplementedInterfaces();
        }

        private void RegisterLogger(ContainerBuilder builder)
        {
            var logFormat = Path.Combine("D:/", "Temp") +
                Path.DirectorySeparatorChar + "{Date}.txt";

            var loggerConfiguration = new SeriLoggerConfiguration();
            var seriLogger = loggerConfiguration.ConfigureLogger(logFormat);

            builder.RegisterInstance(seriLogger);

            builder.RegisterType<Logger.Logger>().AsSelf().AsImplementedInterfaces();

            Log.Logger = seriLogger;
        }
    }
}
