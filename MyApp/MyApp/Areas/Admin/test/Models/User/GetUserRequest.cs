using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class GetUserRequest
    {
        public GetUserRequest(string loginId, string mailAddress)
        {
            LoginId = loginId;
            MailAddress = mailAddress;
        }

        public string LoginId { get; }

        public string MailAddress { get; }
    }
}