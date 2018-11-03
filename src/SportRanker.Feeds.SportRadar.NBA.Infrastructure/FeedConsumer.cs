using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SportRanker.Feeds.SportRadar.NBA.Definitions;
using SportRanker.Feeds.SportRadar.NBA.Interfaces;

namespace SportRanker.Feeds.SportRadar.NBA.Infrastructure
{
    public class FeedConsumer : IFeedConsumer
    {
        private readonly HttpClient _httpClient;

        public FeedConsumer()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ICollection<FeedFixture>> GetFixtureResultsForYesterdayAsync()
        {
            ICollection<FeedFixture> feedFixtures = new List<FeedFixture>();

            var apiKey = "xz332499j8nfpc3cd3494fmk";

            var yesterday = DateTime.UtcNow.AddDays(-1);

            var url = $"https://api.sportradar.us/nba/trial/v5/en/games/{yesterday.Year}/{yesterday.Month}/{yesterday.Day}/schedule.json?api_key={apiKey}";

            var result = await _httpClient.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };

                var feedSchedule = JsonConvert.DeserializeObject<FeedSchedule>(content, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });

                foreach (var game in feedSchedule.Games)
                {
                    if (game.Status == "closed")
                    {
                        feedFixtures.Add(
                            new FeedFixture()
                            {
                                KickOffTimeUtc = game.Scheduled,
                                HomeTeamId = game.Home.Id,
                                HomeTeamName = game.Home.Name,
                                HomeTeamScore = game.HomePoints,
                                AwayTeamId = game.Away.Id,
                                AwayTeamName = game.Away.Name,
                                AwayTeamScore = game.AwayPoints
                            });
                    }
                }
            }

            return feedFixtures;
        }
    }
}
