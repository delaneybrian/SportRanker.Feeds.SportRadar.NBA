using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NBA.Definitions
{
    public class League
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "alias")]
        public string Alias { get; set; }
    }
}
