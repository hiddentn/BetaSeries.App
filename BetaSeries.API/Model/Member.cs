using Newtonsoft.Json;
using System.Collections.Generic;

namespace BetaSeries.API.Model
{
    public class RootMember
    {
        [JsonProperty("member")]
        public Member User;

        [JsonProperty("errors")]
        public List<Error> Err;
    }

    public class Member
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fb_id")]
        public string FaceBookId { get; set; }

        [JsonProperty("login")]
        public string login { get; set; }

        [JsonProperty("xp")]
        public int Xp { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("profile_banner")]
        public string Banner { get; set; }

        [JsonProperty("in_account")]
        public bool LoggedIn { get; set; }

        [JsonProperty("stats")]
        public Stats UserStats { get; set; }

        [JsonProperty("shows")]
        public List<Show> Shows { get; set; }

        [JsonProperty("options")]
        public Options UserOptions { get; set; }
    }
}
