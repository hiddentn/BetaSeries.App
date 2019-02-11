using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaSeries.API.Model
{
    public class Badge
    {
        
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("picture_url")]
        public string Url { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
    public class BadgeList
    {
        [JsonProperty("badges")]
        public List<Badge> Badges;
        [JsonProperty("errors")]
        public List<Error> Err;
    }
}
