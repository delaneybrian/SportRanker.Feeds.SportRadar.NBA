using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SportRanker.Feeds.SportRadar.NBA.Definitions
{
    public class Game
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "coverage")]
        public string Coverage { get; set; }

        [DataMember(Name = "scheduled")]
        public DateTime Scheduled { get; set; }

        [DataMember(Name = "home_points")]
        public int HomePoints { get; set; }

        [DataMember(Name = "away_points")]
        public int AwayPoints { get; set; }

        [DataMember(Name = "track_on_court")]
        public bool TrackOnCourt { get; set; }

        [DataMember(Name = "sr_id")]
        public string SrId { get; set; }

        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        [DataMember(Name = "time_zones")]
        public TimeZone TimeZones { get; set; }

        [DataMember(Name = "venue")]
        public Venue Venue { get; set; }

        [DataMember(Name = "broadcasts")]
        public ICollection<Broadcast> Broadcasts { get; set; }

        [DataMember(Name = "home")]
        public Team Home { get; set; }

        [DataMember(Name = "away")]
        public Team Away { get; set; }
    }
}
