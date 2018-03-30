using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BetaSeries.API
{
     public static class BaseResources
    {
       
        public static class MemberService
        {
            public static string AuthUrl = "/members/auth";
            public static string DisconnectUrl = "/members/destroy";
            public static string InfoUrl = "/members/infos";
            public static string BadgeUrl = "/members/badges";
            public static string SignupUrl = "/members/signup";
            public static string SearchUrl = "/members/search";
            public static string NotificationUrl = "/members/notifications";
            public static string OptionsUrl = "/members/options";
            public static string OptionUrl = "/members/option";
        }

        public static class ShowService
        {
            public static string SearchUrl = "/shows/search";
            public static string DisplayUrl = "/shows/display";
            public static string ArchiveUrl = "/shows/archive";
            public static string EpisodesUrl = "/shows/episodes";
            public static string AddShowUrl = "/shows/show";
            public static string NoteUrl = "/shows/note";
            public static string CharacterUrl = "/shows/characters";
            public static string UserShowsUrl = "/shows/member";
        }
        public static class BadgeService
        {
            public static string BadgeUrl = "/badges/badge";
           
        }
        public static class Settings
        {
            public const string ApiUrl = "http://api.betaseries.com";
            public const string ApiVer = "3.0";
        }
        public static class Filters
        {
            //Not implementes atm 
           public static class MembersFilter
            {
                public const string MemberInfoNoShows = "?fields=id,fb_id,login,xp,xp,avatar,profile_banner,in_account,stats,favorites,options";

            }
        }



    }
}
