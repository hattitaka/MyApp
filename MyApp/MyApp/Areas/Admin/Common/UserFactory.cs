using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Common
{
    public static class UserFactory
    {
        public static User Create(string loginId, string name, string mailAddress, string password)
        {
            var userId = IdFactory.Generate();

            return new User()
            {
                Id = userId,
                Name = name,
                LoginId = loginId,
                MailAddress = mailAddress,
                Password = password,
            };
        }
    }
}