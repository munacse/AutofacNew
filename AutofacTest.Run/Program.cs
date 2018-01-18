using Autofac;
using AutofacTest.Core.Infrastructure;
using System;
using System.Linq;

namespace AutofacTest.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();

            var testRabbitmq = container.Resolve<DataCalculationService>();

            testRabbitmq.AddData();

            testRabbitmq.SubstractData();

            Console.ReadKey();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            var assemblies = AssembliesProvider.Instance.Assemblies.ToArray();
            builder.RegisterAssemblyModules(assemblies);

            builder.RegisterType<DataCalculationService>().AsSelf().AsImplementedInterfaces();

            var container = builder.Build();

            return container;
        }
    }
}
