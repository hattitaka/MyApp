using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.InMemoryInfrastructure.Models
{
    public class GetUserIdList
    {
        public GetUserIdList(List<string> userIdList)
        {
            UserIdList = userIdList;
        }

        public List<string> UserIdList { get; }
    }
}