using MyApp.Areas.Admin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.UserCase.GetContent
{
    public class GetContentRequest
    {
        public GetContentRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}