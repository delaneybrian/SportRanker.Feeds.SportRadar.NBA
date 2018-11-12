using SportRanker.Feeds.SportRadar.NBA.Interfaces;
using System.Threading.Tasks;
using SportRanker.Feeds.SportRadar.NBA.Application.Extensions;

namespace SportRanker.Feeds.SportRadar.NBA.Application
{
    public class FeedProcessor : IFeedProcessor
    {
        public readonly IFeedConsumer _feedConsumer;
        public readonly IPublisher _publisher;
        public readonly IFixtureResultDeriver _fixtureResultDeriver;

        public FeedProcessor(IFeedConsumer feedConsumer,
            IPublisher publisher,
            IFixtureResultDeriver fixtureResultDeriver)
        {
            _feedConsumer = feedConsumer;
            _publisher = publisher;
            _fixtureResultDeriver = fixtureResultDeriver;
        }

        public async Task StartProcessing()
        {
            var feedResults = await _feedConsumer.GetFixtureResultsForYesterdayAsync();

            foreach (var feedResult in feedResults)
            {
                var fixtureResultMaybe = await _fixtureResultDeriver.TryGenerateFixtureResult(feedResult);

                if(fixtureResultMaybe.TrySome(out var fixtureResult))
                    _publisher.PublishFixtureResult(fixtureResult);
            }
        }
    }
}