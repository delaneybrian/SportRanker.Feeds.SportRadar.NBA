using SportRanker.Contracts.SystemEvents;

namespace SportRanker.Feeds.SportRadar.NBA.Interfaces
{
    public interface IPublisher
    {
        void PublishFixtureResult(FixtureResult fixtureResult);
    }
}
