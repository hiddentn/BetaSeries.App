using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BetaSeries.API.Model;
using Newtonsoft.Json;
using BetaSeries.API.Extensions;
using System.Net;

namespace BetaSeries.API
{
    public class UserService : RootService
    {
        public UserService() { Helper = new WebHelper(); }

        public UserService(string _ApiKey, string _UserAgent)
        {
            ApiKey = _ApiKey;
            UserAgent = _UserAgent;
            Helper = new WebHelper(ApiKey, UserAgent);
        }
        public UserService(string _ApiKey, string _UserAgent, string _Token)
        {
            ApiKey = _ApiKey;
            UserAgent = _UserAgent;
            Token = _Token;
            Helper = new WebHelper(ApiKey, UserAgent, Token);
        }

        public async Task<RootAuth> AuthenticateMember(string login, string password)
        {
            var RequestUrl = BaseResources.Settings.ApiUrl + BaseResources.MemberService.AuthUrl;

            var Data = new Dictionary<string, string>();
            Data.Add("login", login);
            Data.Add("password", MD5CryptoServiceProvider.GetMd5String(password));
            FormUrlEncodedContent Content = new FormUrlEncodedContent(Data);

            var RootResult = await Helper.PostAsync<RootAuth>(RequestUrl, Content);
         
            return RootResult;

        }
        public async Task<bool> Logout()
        {
            var RequestUrl = BaseResources.Settings.ApiUrl + BaseResources.MemberService.DisconnectUrl;

            var Data = new Dictionary<string, string>();
            Data.Add("token", Token);
            FormUrlEncodedContent Content = new FormUrlEncodedContent(Data);

            var Res = await Helper.PostAsync<RootError>(RequestUrl, Content);
            if (Res.Err.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           

        }
        public async Task<RootMember> GetUserInfo()
        {
            var RequestUrl = BaseResources.Settings.ApiUrl + BaseResources.MemberService.InfoUrl + "?v=3.0&summary=true";

            //var Options = new Dictionary<string, string>();
            //Options.Add("summary", "true");


            var RootResult = await Helper.GetAsync<RootMember>(RequestUrl);
            return RootResult;

        }

    }
}
