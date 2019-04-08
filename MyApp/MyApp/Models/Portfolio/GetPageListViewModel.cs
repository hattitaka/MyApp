using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Models.Portfolio
{
    public class GetPageListViewModel
    {
        public List<DisplayUserItem> UserList { get; set; }

        public class DisplayUserItem
        {
            public DisplayUserItem(string id, string name)
            {
                Id = id;
                Name = name;
            }

            public string Id { get; }

            public string Name { get; }
        }
    }
}