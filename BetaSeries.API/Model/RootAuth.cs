using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaSeries.API.Model
{
    public class AuthUser
    {
        [JsonProperty("id")]
        public int id;

        [JsonProperty("login")]
        public string Login;

        [JsonProperty("xp")]
        public int Xp;

        [JsonProperty("in_acount")]
        public bool LoggedIn;

        //    {
        //"user": {
        //    "id": 277502,
        //    "login": "Mdr120",
        //    "xp": 4527,
        //    "in_account": true
        //},
        //"token": "5c39251ed1b8",
        //"hash": "51d9479c57d49bcd760d0a898df15023",
        //"errors": []
        //}
    }
    public class RootAuth
    {
        [JsonProperty("user")]
        public AuthUser User;


        [JsonProperty("token")]
        public string Token;

        [JsonProperty("hash")]
        public string hash;

        [JsonProperty("errors")]
        public List<Error> Err;
    }
}
