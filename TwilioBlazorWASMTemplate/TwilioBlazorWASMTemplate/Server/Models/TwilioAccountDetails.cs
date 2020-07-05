using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwilioBlazorWASMTemplate.Server.Models
{
    // model should on be used on server side for fetching account and APi information
    public class TwilioAccountDetails
    {

        public string AccountSID { get; set; }
        public string AuthToken { get; set; }

    }



}
