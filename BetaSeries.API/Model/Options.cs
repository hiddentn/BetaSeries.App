using Newtonsoft.Json;


namespace BetaSeries.API.Model
{


    public class Options
    {

        [JsonProperty("downloaded")]
        public bool Downloaded { get; set; }

        [JsonProperty("notation")]
        public bool Notation { get; set; }

        [JsonProperty("timelag")]
        public bool timeLag { get; set; }

        [JsonProperty("global")]
        public bool Global { get; set; }

        [JsonProperty("specials")]
        public bool Specials { get; set; }

        [JsonProperty("episodes_tri")]
        public int EpTri { get; set; }

        [JsonProperty("friendship")]
        public string FriendShip { get; set; }
    }
}
