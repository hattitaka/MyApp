using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository.Models
{
    public class GetUserListResponse
    {
        public GetUserListResponse(List<UserItem> userList)
        {
            UserList = userList;
        }

        public List<UserItem> UserList { get; }
    }
}