using System.Threading.Tasks;
using Optional;
using SportRanker.Contracts.Dto;
using SportRanker.Contracts.SystemEvents;
using SportRanker.Feeds.SportRadar.NBA.Application.Extensions;
using SportRanker.Feeds.SportRadar.NBA.Definitions;
using SportRanker.Feeds.SportRadar.NBA.Interfaces;

namespace SportRanker.Feeds.SportRadar.NBA.Application
{
    public class FixtureResultDeriver : IFixtureResultDeriver
    {
        private readonly IDataProvider _dataProvider;

        public FixtureResultDeriver(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Option<FixtureResult>> TryGenerateFixtureResult(FeedFixture feedFixture)
        {
            var fixtureMaybe = await _dataProvider.GetFixtureByProviderIdAsync(feedFixture.FeedSource, feedFixture.ProviderFixtureId);

            if (!fixtureMaybe.TrySome(out var fixture))
            {
                var homeTeamMaybe =
                    await _dataProvider.GetTeamByProviderIdAsync(feedFixture.FeedSource, feedFixture.HomeTeamId);

                var awayTeamMaybe =
                    await _dataProvider.GetTeamByProviderIdAsync(feedFixture.FeedSource, feedFixture.AwayTeamId);

                if (homeTeamMaybe.TrySome(out var homeTeam) &&
                    awayTeamMaybe.TrySome(out var awayTeam))
                {
                    return Option.Some(new FixtureResult()
                    {
                        SportId = SportId.NBA,
                        Source = SourceId.SportRadar,
                        SourceId = feedFixture.ProviderFixtureId,
                        HomeTeamId = homeTeam.Id,
                        HomeTeamName = homeTeam.Name,
                        HomeTeamScore = feedFixture.HomeTeamScore,
                        AwayTeamId = awayTeam.Id,
                        AwayTeamName = awayTeam.Name,
                        AwayTeamScore = feedFixture.AwayTeamScore,
                        KickOffTimeUtc = feedFixture.KickOffTimeUtc,
                    });
                }
            }

            return Option.None<FixtureResult>();
        }
    }
}
