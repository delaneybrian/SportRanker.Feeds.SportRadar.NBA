using SportRanker.Feeds.SportRadar.NBA.Interfaces;
using System.Threading.Tasks;

namespace SportRanker.Feeds.SportRadar.NBA.Application
{
    public class FeedProcessor : IFeedProcessor
    {
        public readonly IFeedConsumer _feedConsumer;
        public readonly IPublisher _publisher;

        public FeedProcessor(IFeedConsumer feedConsumer,
            IPublisher publisher)
        {
            _feedConsumer = feedConsumer;
            _publisher = publisher;
        }

        public async Task StartProcessing()
        {
            var feedResults = await _feedConsumer.GetFixtureResultsForYesterdayAsync();

            foreach (var feedResult in feedResults)
            {
                var fixtureResult = ResultConverter.ConvertFromFeedFixtureResult(feedResult);

                _publisher.PublishFixtureResult(fixtureResult);
            }
        }
    }
}