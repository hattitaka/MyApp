using MyApp.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.InDataBaseInfrastructure
{
    public class UserRepository
    {
        private MyAppDBEntities data = new MyAppDBEntities();

        public bool CheckUser(string name, string address)
        {
            var user = data.User.FirstOrDefault(x => x.Name == name && x.Address == address);

            return (user != null);
        }

        public UserDetails GetUserDetails(int id)
        {
            // test
            return new UserDetails("testId", "testLoginId", "testName", "testMailAddress");
        }
    }
}