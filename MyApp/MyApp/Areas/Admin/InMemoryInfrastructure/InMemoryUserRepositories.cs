using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.InMemoryInfrastructure
{
    public class InMemoryUserRepositories
    {
        private static Dictionary<string, string> data = new Dictionary<string, string>
        {
            { "user_1", "テスト太郎" },
            { "user_2", "テストはな子" },
            { "user_3", "織田信長" },
            { "user_4", "豊臣秀吉"}
        };

        public User GetUser(string id)
        {
            if(data.TryGetValue(id, out var name))
            {
                return new User(id, name);
            }
            else
            {
                return null;
            }
        }

        public bool CheckUser(User user)
        {
            return data.TryGetValue(user.Id, out var name);
        }
    }
}