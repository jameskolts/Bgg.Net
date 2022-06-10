using Autofac;
using Autofac.Core;
using Bgg.Net.Common.Infrastructure.IOC;
using Serilog;

namespace Bgg.Net.Client.IOC
{
    public static class BootStrapper
    {
        private static ILifetimeScope _scope;

        public static void Start()
        {
            if (_scope != null)
                return;

            var builder = new ContainerBuilder();

            builder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger();
            }).SingleInstance();

            builder.RegisterBggCommon().RegisterBggClient();

            _scope = builder.Build();
        }

        public static void Stop()
        {
            _scope.Dispose();
        }

        public static T Resolve<T>()
        {
            if (_scope == null)
                throw new Exception("AutofacRegistrar has not started.");

            return _scope.Resolve<T>();
        }

        public static T Resolve<T>(params Parameter[] parameters)
        {
            if (_scope == null)
                throw new Exception("AutofacRegistrar has not started.");

            return _scope.Resolve<T>(parameters);
        }
    }
}
