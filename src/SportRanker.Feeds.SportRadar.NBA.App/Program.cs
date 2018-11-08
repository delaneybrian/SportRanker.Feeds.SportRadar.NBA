using System;
using Autofac;
using SportRanker.Feeds.SportRadar.NBA.Interfaces;

namespace SportRanker.Feeds.SportRadar.NBA.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AppBootstrapper.Bootstrap();

            var feedProcessor = container.Resolve<IFeedProcessor>();

            feedProcessor.StartProcessing().Wait();

            Console.ReadKey();
        }
    }
}
