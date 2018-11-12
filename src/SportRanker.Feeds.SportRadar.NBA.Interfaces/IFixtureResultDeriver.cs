using System.Threading.Tasks;
using Optional;
using SportRanker.Contracts.SystemEvents;
using SportRanker.Feeds.SportRadar.NBA.Definitions;

namespace SportRanker.Feeds.SportRadar.NBA.Interfaces
{
    public interface IFixtureResultDeriver
    {
        Task<Option<FixtureResult>> TryGenerateFixtureResult(FeedFixture feedFixture);
    }
}
