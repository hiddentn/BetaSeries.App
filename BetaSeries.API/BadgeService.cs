using BetaSeries.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaSeries.API
{
    public class BadgeService : RootService
    {

        public BadgeService() { Helper = new WebHelper(); }

        public BadgeService(string _ApiKey, string _UserAgent)
        {
            ApiKey = _ApiKey;
            UserAgent = _UserAgent;
            Helper = new WebHelper(ApiKey, UserAgent);
        }
        public BadgeService(string _ApiKey, string _UserAgent, string _Token)
        {
            ApiKey = _ApiKey;
            UserAgent = _UserAgent;
            Token = _Token;
            Helper = new WebHelper(ApiKey, UserAgent, Token);
        }
        public async Task<BadgeList> GetUserBadges(int _Id)
        {
            var RequestUrl = BaseResources.Settings.ApiUrl + BaseResources.MemberService.BadgeUrl +"?id="+_Id;
            var RootResult = await Helper.GetAsync<BadgeList>(RequestUrl);
            List<int> Idlist = new List<int>();
            RootResult.Badges.ForEach(item =>
            {
                Idlist.Add(item.Id);
            });
            var Ids = string.Join(",", Idlist);
            RequestUrl = BaseResources.Settings.ApiUrl + BaseResources.BadgeService.BadgeUrl + "?id=" + Ids;
            var Second = await Helper.GetAsync<BadgeList>(RequestUrl);
            for (int i = 0; i < RootResult.Badges.Count; i++) RootResult.Badges[i].Url = Second.Badges[i].Url;



            return RootResult;


        }
    }
}
