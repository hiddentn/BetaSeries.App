using Newtonsoft.Json;

namespace BetaSeries.API.Model
{
    public class Stats
    {
        [JsonProperty("friends")]
        public int FriendCount { get; set; }

        [JsonProperty("shows")]
        public int ShowCount { get; set; }

        [JsonProperty("seasons")]
        public int SeasonCount { get; set; }

        [JsonProperty("episodes")]
        public int EpisodeCount { get; set; }

        [JsonProperty("comments")]
        public int CommentCount { get; set; }

        [JsonProperty("progress")]
        public float Progress { get; set; }

        [JsonProperty("episodes_to_watch")]
        public int EpisodesToWatch { get; set; }

        [JsonProperty("time_on_tv")]
        public float TimeOnTV { get; set; }

        [JsonProperty("time_to_spend")]
        public float TimeToSpentOnTV { get; set; }

        [JsonProperty("movies")]
        public int MovieCount { get; set; }

        [JsonProperty("badges")]
        public int BadgeCount { get; set; }

        [JsonProperty("member_since_days")]
        public int MemberSinceDays { get; set; }

        [JsonProperty("friends_of_friends")]
        public int SocialCircleFriendsCount { get; set; }

        [JsonProperty("episodes_per_month")]
        public int EpisodesPerMonth { get; set; }

        [JsonProperty("favorite_day")]
        public string FavDay { get; set; }

        [JsonProperty("five_stars_percent")]
        public float FiveStarPercent { get; set; }

        [JsonProperty("four-five_stars_total")]
        public float FourFiveStarTotal { get; set; }

        [JsonProperty("streak_days")]
        public int StreakDays { get; set; }

        [JsonProperty("favorite_genre")]
        public string FavGenre { get; set; }

        [JsonProperty("written_words")]
        public int WrittenWords { get; set; }

        [JsonProperty("without_days")]
        public int DaysWithout { get; set; }

        [JsonProperty("shows_finished")]
        public int ShowsFinished { get; set; }

        [JsonProperty("shows_current")]
        public int ShowsCurrent { get; set; }

        [JsonProperty("shows_to_watch")]
        public int ShowsToWatch { get; set; }

        [JsonProperty("shows_abandoned")]
        public int ShowsAbandoned { get; set; }

        [JsonProperty("movies_to_watch")]
        public int MoviesToWatch { get; set; }

        [JsonProperty("time_on_movies")]
        public float TimeOnMovies { get; set; }
    }
}