using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BetaSeries.API.v2
{
    class WebHelper
    {
        public static HttpClientHandler Handler = new HttpClientHandler
        {
            UseProxy = false,
            UseCookies = false,
            UseDefaultCredentials = false,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        public string Token { get; set; }
        public string ApiKey { get; set; }
        public string UserAgent { get; set; }
        public string ApiVer { get; set; }

        public WebHelper() { }
        public WebHelper(string _ApiKey, string _UserAgent)
        {
            ApiVer = "3.0";
            ApiKey = _ApiKey;
            UserAgent = _UserAgent;
        }
        public WebHelper(string _ApiKey, string _UserAgent, string _Token)
        {
            ApiVer = "3.0";
            ApiKey = _ApiKey;
            UserAgent = _UserAgent;
            Token = _Token;
        }
        public HttpClient GetHttpClient()
        {
            HttpClient Client = new HttpClient(Handler);
            Client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            Client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
            Client.DefaultRequestHeaders.Add("X-BetaSeries-Version", ApiVer);
            Client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            if (!string.IsNullOrEmpty(ApiKey)) Client.DefaultRequestHeaders.Add("X-BetaSeries-Key", ApiKey);
            if (!string.IsNullOrEmpty(Token)) Client.DefaultRequestHeaders.Add("X-BetaSeries-Token", Token);
            if (!string.IsNullOrEmpty(UserAgent)) Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            return Client;
        }

        public async Task<T> PostAsync<T>(string _RequestUrl, FormUrlEncodedContent _Content)
        {
            using (HttpClient Client = GetHttpClient())
            {
                using (HttpResponseMessage Response = await Client.PostAsync(_RequestUrl, _Content))
                {
                    var Result = await Response.Content.ReadAsStringAsync();
                    var RootResult = JsonConvert.DeserializeObject<T>(Result);
                    return RootResult;
                }
            }
            
        }
        public async Task<T> GetAsync<T>(string _RequestUrl)
        {
            using (HttpClient Client = GetHttpClient())
            {
                using (HttpResponseMessage Response = await Client.GetAsync(_RequestUrl))
                {
                    var Result = await Response.Content.ReadAsStringAsync();
                    var RootResult = JsonConvert.DeserializeObject<T>(Result);
                    return RootResult;
                }
            }
        }
        public async Task<T> GetAsync<T>(string _RequestUrl, Dictionary<string, string> _Options)
        {
            using (HttpClient Client = GetHttpClient())
            {
                foreach (var item in _Options)
                {
                    Client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
                using (HttpResponseMessage Response = await Client.GetAsync(_RequestUrl))
                {
                    var Result = await Response.Content.ReadAsStringAsync();
                    var RootResult = JsonConvert.DeserializeObject<T>(Result);
                    return RootResult;
                }
            }
            
        }
    }
}
