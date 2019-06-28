using MyApp.Areas.Admin.Models.Models;
using MyApp.Areas.Admin.Models.UserCase.ChangeUserInfo;
using MyApp.Areas.Admin.Models.UserCase.CheckUser;
using MyApp.Areas.Admin.Models.UserCase.GetUserDetails;
using MyApp.Areas.Admin.Models.UserCase.GetUserSummaries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Areas.Admin.Models.Repository
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static List<User> data = new List<User>()
        {
            new User()
            {
                Id = "userId1",
                Name = "name1",
                LoginId = "login1",
                Password = "password1",
                MailAddress = "address1@gmo.jp"
            },
            new User()
            {
                Id = "userId2",
                Name = "name2",
                LoginId = "login2",
                Password = "password2",
                MailAddress = "address2@gmo.jp"
            },
        };

        public ChangeUserInfoResponse ChangeUserInfo(ChangeUserInfoRequest req)
        {
            var target = data.FirstOrDefault(x => x.Id == req.Id);

            if (target == null)
            {
                throw new System.Exception("Invalid request");
            }

            target.Name = req.Name;
            target.MailAddress = req.MailAddress;
            target.Password = req.Password;

            return new ChangeUserInfoResponse(target.Name, target.MailAddress, target.Password);
        }

        public CheckUserResponse CheckUser(CheckUserRequest req)
        {
            var target = data.FirstOrDefault(x => x.LoginId == req.LoginId && x.Password == req.Password);

            if (target == null)
            {
                return new CheckUserResponse();
            }

            return new CheckUserResponse(target.Id);
        }

        public GetUserDetailsResponse GetUserDetails(GetUserDetailsRequest req)
        {
            var target = data.FirstOrDefault(x => x.Id == req.UserId);

            if (target == null)
            {
                var errorMessage = "user is not found";
                return new GetUserDetailsResponse(errorMessage);
            }

            return new GetUserDetailsResponse(target);
        }

        public GetUserSummariesResponse GetUserSummaries()
        {
            var summaries = data
                .Select(x => new UserSummary() { Id = x.Id, Name = x.Name })
                .ToList();

            return new GetUserSummariesResponse(summaries);
        }
    }
}