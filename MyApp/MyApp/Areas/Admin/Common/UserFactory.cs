using MyApp.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Common
{
    public static class UserFactory
    {
        public static UserDetails Create(string loginId, string name, string mailAddress, string password)
        {
            string userId = UserIdFactory.GetUserId();

            return new UserDetails(userId, loginId, name, mailAddress, password);
        }
    }
}