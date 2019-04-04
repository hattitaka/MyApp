using MyApp.Areas.Admin.Models;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin
{
    public class InMemoryUserRepositories
    {
        private static Dictionary<string, string> nameData = new Dictionary<string, string>
        {
            { "user_1", "テスト太郎" },
            { "user_2", "テストはな子" },
            { "user_3", "織田信長" },
            { "user_4", "豊臣秀吉"}
        };

        private static Dictionary<string, string> loginIdData = new Dictionary<string, string>
        {
            { "user_1", "test-tarou" },
            { "user_2", "test-hanako" },
            { "user_3", "nobunobu" },
            { "user_4", "hidehide" }
        };

        private static Dictionary<string, string> mailAddressData = new Dictionary<string, string>
        {
            { "user_1", "test-tarou@gmo.jp" },
            { "user_2", "test-hanako@gmo.jp" },
            { "user_3", "nobunobu@gmo.jp" },
            { "user_4", "hidehide@gmo.jp" }
        };

        //public User GetUser(string id)
        //{
        //    if(nameData.TryGetValue(id, out var name) && mailAddressData.TryGetValue(id, out var address))
        //    {
        //        return new User(id, name, address);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public bool CheckUser(string id, string address)
        {
            mailAddressData.TryGetValue(id, out var data);
            return (address == data);
        }

        //public void RegisterUser(User user)
        //{
        //    nameData.Add(user.Id, user.Name);
        //}

        public UserDetails GetUserDetails()
        {
            return new UserDetails("testId", "testLoginId", "testName", "testMailAddress");
        }
    }
}