using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NBA.Definitions
{
    public class Broadcast
    {
        [DataMember(Name = "network")]
        public string Network { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        [DataMember(Name = "channel")]
        public string Channel { get; set; }
    }
}
