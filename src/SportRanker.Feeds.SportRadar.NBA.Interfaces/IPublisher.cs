using SportRanker.Feeds.SportRadar.NBA.Contracts;

namespace SportRanker.Feeds.SportRadar.NBA.Interfaces
{
    public interface IPublisher
    {
        void PublishFixtureResult(FixtureResult fixtureResult);
    }
}
