using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NBA.Definitions.Api
{
    [DataContract]
    public class ApiTeam
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "rating")]
        public long Rating { get; set; }

        [DataMember(Name = "imageUrl")]
        public string ImageUrl { get; set; }

        [DataMember(Name = "sportRadarId")]
        public string SportRadarId { get; set; }

        [DataMember(Name = "_links")]
        public Links Links { get; set; }
    }

    [DataContract]
    public class Links
    {
        public Self self { get; set; }
        public Teams teams { get; set; }
        public Sport sport { get; set; }
        public City city { get; set; }
        public State state { get; set; }
    }

    [DataContract]
    public class Self
    {
        public string href { get; set; }
    }

    [DataContract]
    public class Teams
    {
        public string href { get; set; }
    }

    [DataContract]
    public class Sport
    {
        public string href { get; set; }
    }

    [DataContract]
    public class City
    {
        public string href { get; set; }
    }

    [DataContract]
    public class State
    {
        public string href { get; set; }
    }

}
