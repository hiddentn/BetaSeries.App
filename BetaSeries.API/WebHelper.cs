using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace BetaSeries.API
{
    public class WebHelper
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

        public WebHelper() { }
        public WebHelper(string _ApiKey, string _UserAgent)
        {
            ApiKey = _ApiKey;
            UserAgent = _UserAgent;
        }
        public WebHelper(string _ApiKey, string _UserAgent, string _Token)
        {
            ApiKey = _ApiKey;
            UserAgent = _UserAgent;
            Token = _Token;
        }

        public void ApplyDefaultHeaders(ref HttpClient Client)
        {
            Client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            Client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
            Client.DefaultRequestHeaders.Add("X-BetaSeries-Version", BaseResources.Settings.ApiVer);
            Client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

        }


        public async Task<T> PostAsync<T>(string _RequestUrl, FormUrlEncodedContent _Content)
        {
            var Client = new HttpClient(Handler);
            ApplyDefaultHeaders(ref Client);
            if (!string.IsNullOrEmpty(ApiKey)) Client.DefaultRequestHeaders.Add("X-BetaSeries-Key", ApiKey);
            if (!string.IsNullOrEmpty(Token)) Client.DefaultRequestHeaders.Add("X-BetaSeries-Token", Token);
            if (!string.IsNullOrEmpty(UserAgent)) Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            HttpResponseMessage Response = await Client.PostAsync(_RequestUrl, _Content);

            var Result = await Response.Content.ReadAsStringAsync();
            var RootResult = JsonConvert.DeserializeObject<T>(Result);
            return RootResult;
        }

        public async Task<T> GetAsync<T>(string _RequestUrl)
        {
            var Client = new HttpClient(Handler);
            ApplyDefaultHeaders(ref Client);
            if (!string.IsNullOrEmpty(ApiKey)) Client.DefaultRequestHeaders.Add("X-BetaSeries-Key", ApiKey);
            if (!string.IsNullOrEmpty(Token)) Client.DefaultRequestHeaders.Add("X-BetaSeries-Token", Token);
            if (!string.IsNullOrEmpty(UserAgent)) Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            HttpResponseMessage Response = await Client.GetAsync(_RequestUrl);

            var Result = await Response.Content.ReadAsStringAsync();
            var RootResult = JsonConvert.DeserializeObject<T>(Result);
            return RootResult;
        }
        public async Task<T> GetAsync<T>(string _RequestUrl, Dictionary<string, string> _Options)
        {
            var Client = new HttpClient(Handler);
            ApplyDefaultHeaders(ref Client);
            if (!string.IsNullOrEmpty(ApiKey)) Client.DefaultRequestHeaders.Add("X-BetaSeries-Key", ApiKey);
            if (!string.IsNullOrEmpty(Token)) Client.DefaultRequestHeaders.Add("X-BetaSeries-Token", Token);
            if (!string.IsNullOrEmpty(UserAgent)) Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            foreach (var item in _Options)
            {
              Client.DefaultRequestHeaders.Add(item.Key,item.Value);
            }
           

            HttpResponseMessage Response = await Client.GetAsync(_RequestUrl);

            var Result = await Response.Content.ReadAsStringAsync();
            var RootResult = JsonConvert.DeserializeObject<T>(Result);
            return RootResult;
        }
    }
}

