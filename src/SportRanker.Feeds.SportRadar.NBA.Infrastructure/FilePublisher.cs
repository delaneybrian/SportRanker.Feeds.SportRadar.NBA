using SportRanker.Contracts.SystemEvents;
using SportRanker.Feeds.SportRadar.NBA.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace SportRanker.Feeds.SportRadar.NBA.Infrastructure
{
    public class FilePublisher : IPublisher
    {
        private string fileLocation = @"C:/Fixtures/nba.txt";

        public void PublishFixtureResult(FixtureResult fixtureResult)
        {
            var json = JsonConvert.SerializeObject(fixtureResult);

            using (StreamWriter writer = File.AppendText(fileLocation))
            {
                writer.WriteLine(json);
            }
        }
    }
}
