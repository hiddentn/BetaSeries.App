using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
    public class User
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        [JsonProperty("remaining")]
        public string Remaining { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }
    }
}