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

        public class UserItem
        {
            public UserItem(string id, string name)
            {
                Id = id;
                Name = name;
            }

            public string Id { get; }

            public string Name { get; }
        }
    }
}