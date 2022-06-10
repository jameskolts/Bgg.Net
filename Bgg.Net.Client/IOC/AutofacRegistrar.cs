using Autofac;
using Bgg.Net.Client.Infrastructure.Commands;
using Bgg.Net.Client.Infrastructure.Helpers;
using Bgg.Net.Client.ViewModels;

namespace Bgg.Net.Client.IOC
{
    public static class AutofacRegistrar
    {
        public static ContainerBuilder RegisterBggClient(this ContainerBuilder builder)
        {
            builder.RegisterType<CollectionHelper>().As<ICollectionHelper>().AsSelf();
            builder.RegisterType<CollectionViewModel>().As<ICollectionViewModel>().AsSelf();
            builder.RegisterType<CollectionItemTappedCommand>().As<ICollectionItemTapped>().AsSelf();
            builder.RegisterType<CollectionItemDetailsViewModel>().As<ICollectionItemDetailsViewModel>().AsSelf();

            return builder;
        }
    }
}
