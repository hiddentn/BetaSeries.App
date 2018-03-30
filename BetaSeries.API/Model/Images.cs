using Newtonsoft.Json;

namespace BetaSeries.API.Model
{

    public class Images
    {
        [JsonProperty("show")]
        public string Show { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("box")]
        public string Box { get; set; }

        [JsonProperty("poster")]
        public string Poster { get; set; }
    }

}