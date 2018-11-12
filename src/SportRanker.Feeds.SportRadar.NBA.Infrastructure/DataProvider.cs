using System.Collections.Generic;
using System.Threading.Tasks;
using Optional;
using SportRanker.Contracts.Dto;
using SportRanker.Feeds.SportRadar.NBA.Interfaces;

namespace SportRanker.Feeds.SportRadar.NBA.Infrastructure
{
    public class DataProvider : IDataProvider
    {
        public async Task<Option<Fixture>> GetFixtureByProviderIdAsync(SourceId provider, string providerId)
        {
            return Option.None<Fixture>();
        }

        public async Task<Option<Team>> GetTeamByProviderIdAsync(SourceId provider, string providerId)
        {
            return Option.Some(new Team()
            {
                CityId = 1,
                CityName = "Petersburg",
                ExternalMappings = new List<ExternalMapping>()
                {
                    new ExternalMapping()
                    {
                        Source = SourceId.Internal,
                        SourceId = "hello"
                    }
                },
                Id = 1,
                ImageUrl = "Htt",
                Name = "Steelers",
                Rating = 1500,
                SportId = 1,
                SportName = "Name",
                StateId = 1,
                StateName = "Washington"
            });
        }
    }
}
