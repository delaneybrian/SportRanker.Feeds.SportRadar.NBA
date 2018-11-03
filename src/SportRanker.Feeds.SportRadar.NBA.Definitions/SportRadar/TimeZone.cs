using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NBA.Definitions
{
    public class TimeZone
    {
        [DataMember(Name = "venue")]
        public string Venue { get; set; }

        [DataMember(Name = "home")]
        public string Home { get; set; }

        [DataMember(Name = "away")]
        public string Away { get; set; }
    }
}
