using Newtonsoft.Json;
using System.Collections.Generic;


namespace BetaSeries.API.Model { 
public class Show
{
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("thetvdb_id")]
        public int ThetvdbId { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("seasons")]
        public int Seasons { get; set; }

        [JsonProperty("seasons_details")]
        public List<SeasonDetail> SeasonsDetails { get; set; }

        [JsonProperty("episodes")]
        public string Episodes { get; set; }

        [JsonProperty("followers")]
        public string Followers { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("similars")]
        public string Similars { get; set; }

        [JsonProperty("characters")]
        public string Characters { get; set; }

        [JsonProperty("creation")]
        public string Creation { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("notes")]
        public Note Notes { get; set; }

        [JsonProperty("in_account")]
        public bool InAccount { get; set; }
        
        [JsonProperty("images")]
        public Images ImageResources { get; set; }

        [JsonProperty("aliases")]
        public List<string> Aliases { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("resource_url")]
        public string ResourceUrl { get; set; }









        //[JsonProperty("remaining")]
        //public int Remaining { get; set; }

        //[JsonProperty("unseen")]
        //public List<Episode> UnseenEpisodes { get; set; }

        

       

}
}