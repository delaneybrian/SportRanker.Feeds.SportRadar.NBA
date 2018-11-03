using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NBA.Definitions
{
    public class Team
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "alias")]
        public string Alias { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "sr_id")]
        public string SrId { get; set; }

        [DataMember(Name = "reference")]
        public string Reference { get; set; }
    }
}
