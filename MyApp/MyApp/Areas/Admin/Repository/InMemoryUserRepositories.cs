using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Repository.Models;
using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Repository.Models;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin
{
    public class InMemoryUserRepositories
    {
        private static List<UserDetails> testData = new List<UserDetails>
        {
            new UserDetails("asdfadsfasdf", "loginid_1", "name_1" , "mailaddress_1@test.com"),
            new UserDetails("asdfasdf", "loginid_2", "name_2" , "mailaddress_2@test.com"),
            new UserDetails("qweoijfa", "loginid_3", "name_3" , "mailaddress_3@test.com"),
            new UserDetails("4a9g8jha", "loginid_4", "name_4" , "mailaddress_4@test.com"),
            new UserDetails("agh489pahdag", "loginid_5", "name_5" , "mailaddress_5@test.com"),
        };

        public CheckUserResponse CheckUser(CheckUserRequest req)
        {
            var target = testData.FirstOrDefault(x => x.LoginId==req.LoginId && x.MailAddress==req.Address);

            if(target == null)
            {
                return new CheckUserResponse();
            }

            return new CheckUserResponse(target.Id, target.LoginId, target.Name, target.MailAddress);
        }

        public void RegisterUser(RegisterUserRequest req)
        {
            string userId = UserIdFactory.GetUserId();

            testData.Add(new UserDetails(userId, req.LoginId, req.Name, req.MailAddress));
        }

        public GetUserDetailsResponse GetUserDetails(string id)
        {
            var res = testData.FirstOrDefault(x => x.Id == id);

            return new GetUserDetailsResponse(res.Name, res.MailAddress, res.LoginId);
        }

        public GetUserIdList GetUserIdList()
        {
            var res = testData.Select(x => x.Id).ToList();
            return new GetUserIdList(res);
        }
    }
}