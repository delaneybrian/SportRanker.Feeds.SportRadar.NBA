using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Optional;
using SportRanker.Contracts.Dto;
using SportRanker.Feeds.SportRadar.NBA.Definitions.Api;
using SportRanker.Feeds.SportRadar.NBA.Interfaces;

namespace SportRanker.Feeds.SportRadar.NBA.Infrastructure
{
    public class DataProvider : IDataProvider
    {
        private readonly HttpClient _httpClient;

        public DataProvider()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Option<Fixture>> GetFixtureByProviderIdAsync(SourceId provider, string providerId)
        {
            var result = await _httpClient.GetAsync($"http://sports-rivals.appspot.com/api/fixtures/search/findTopBySportsRadarId?name={providerId}");

            if (result.IsSuccessStatusCode)
                return Option.Some<Fixture>(new Fixture());

            return Option.None<Fixture>();
        }

        public async Task<Option<Team>> GetTeamByProviderIdAsync(SourceId provider, string providerId)
        {
            var result = await _httpClient.GetAsync($"http://sports-rivals.appspot.com/api/teams/search/findFirstBySportRadarId?sportRadarId={providerId}");

            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStringAsync();

                var apiTeam = JsonConvert.DeserializeObject<ApiTeam>(body);

                return Option.Some(new Team()
                {
                    ExternalMappings = new List<ExternalMapping>()
                {
                    new ExternalMapping()
                    {
                        Source = SourceId.SportRadar,
                        SourceId = providerId
                    }
                },
                    Id = apiTeam.Id,
                    ImageUrl = apiTeam.ImageUrl,
                    Name = apiTeam.Name,
                    Rating = apiTeam.Rating,
                    SportId = (long)SportId.NBA,
                    SportName = SportId.NBA.ToString(),
                });
            }

            return Option.None<Team>();
        }
    }
}
