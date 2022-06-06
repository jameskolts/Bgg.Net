using Autofac;
using Bgg.Net.Client.ViewModels;

namespace Bgg.Net.Client.IOC
{
    public static class AutofacRegistrar
    {
        public static ContainerBuilder RegisterBggClient(this ContainerBuilder builder)
        {
            builder.RegisterType<CollectionViewModel>().As<ICollectionViewModel>().AsSelf();

            return builder;
        }
    }
}
