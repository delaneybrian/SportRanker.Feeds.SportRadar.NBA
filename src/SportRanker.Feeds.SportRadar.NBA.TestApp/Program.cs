using Autofac;
using SportRanker.Feeds.SportRadar.NBA.Interfaces;

namespace SportRanker.Feeds.SportRadar.NBA.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AppBootstrapper.Bootstrap();

            var feedProcessor = container.Resolve<IFeedProcessor>();

            feedProcessor.ProcessHistoricalFixtures(3).Wait();
        }
    }
}
