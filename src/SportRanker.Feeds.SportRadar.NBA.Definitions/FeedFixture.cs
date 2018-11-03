using System;

namespace SportRanker.Feeds.SportRadar.NBA.Definitions
{
    public class FeedFixture
    {
        public DateTime KickOffTimeUtc { get; set; }
        public string HomeTeamId { get; set; }
        public string AwayTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}
