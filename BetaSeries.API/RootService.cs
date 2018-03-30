using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BetaSeries.API
{
    public class RootService
    {
        public string Token { get; set; }
        public string ApiKey { get; set; }
        public string UserAgent { get; set; }

        public WebHelper Helper;

    }
}
