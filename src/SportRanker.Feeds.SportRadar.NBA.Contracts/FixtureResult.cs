using System;
using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NBA.Contracts
{
    [DataContract]
    public class FixtureResult
    {
        [DataMember] public SportId SportId { get; set; }

        [DataMember] public FeedSource FeedSource { get; set; }

        [DataMember] public DateTime KickOffTimeUtc { get; set; }

        [DataMember] public string HomeTeamId { get; set; }

        [DataMember] public string AwayTeamId { get; set; }

        [DataMember] public string HomeTeamName { get; set; }

        [DataMember] public string AwayTeamName { get; set; }

        [DataMember] public int HomeTeamScore { get; set; }

        [DataMember] public int AwayTeamScore { get; set; }
    }
}
