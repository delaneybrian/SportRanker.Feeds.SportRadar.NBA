using SportRanker.Feeds.SportRadar.NBA.Definitions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportRanker.Feeds.SportRadar.NBA.Interfaces
{
    public interface IFeedConsumer
    {
        Task<ICollection<FeedFixture>> GetFixtureResultsForYesterdayAsync();
    }
}
