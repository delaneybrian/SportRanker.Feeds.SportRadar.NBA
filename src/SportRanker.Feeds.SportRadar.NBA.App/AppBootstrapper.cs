using Autofac;
using SportRanker.Feeds.SportRadar.NBA.Application;
using SportRanker.Feeds.SportRadar.NBA.Infrastructure;
using SportRanker.Feeds.SportRadar.NBA.Interfaces;

namespace SportRanker.Feeds.SportRadar.NBA.App
{
    public class AppBootstrapper
    {
        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<FeedProcessor>()
                .As<IFeedProcessor>();

            builder
                .RegisterType<FeedConsumer>()
                .As<IFeedConsumer>();

            builder
                .RegisterType<Publisher>()
                .As<IPublisher>();

            builder
                .RegisterType<FixtureResultDeriver>()
                .As<IFixtureResultDeriver>();

            builder
                .RegisterType<DataProvider>()
                .As<IDataProvider>();

            return builder.Build();
        }
    }
}
