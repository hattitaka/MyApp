using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models.Text
{
    public class GetTextRequest
    {
        public GetTextRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}