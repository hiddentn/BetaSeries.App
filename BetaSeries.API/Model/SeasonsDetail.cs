using Newtonsoft.Json;
namespace BetaSeries.API.Model
{

    public class SeasonDetail
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("episodes")]
        public int EpisodeNumber { get; set; }
    }
}