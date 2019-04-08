using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository
{
    public class UserRepository
    {
        private MyAppDBEntities1 db = new MyAppDBEntities1();

        public CheckUserResponse CheckUser(CheckUserRequest req)
        {
            var target = db.User.FirstOrDefault(x => x.LoginId == req.LoginId && x.MailAddress == req.Address);

            if (target == null)
            {
                return new CheckUserResponse();
            }

            return new CheckUserResponse(target.Id, target.LoginId, target.Name, target.MailAddress);
        }

        public void RegisterUser(RegisterUserRequest req)
        {
            string userId = UserIdFactory.GetUserId();

            db.User.Add(new User()
            {
                Id = userId,
                LoginId = req.LoginId,
                Name = req.Name,
                MailAddress = req.MailAddress
            });

            db.SaveChanges();
        }

        public void SaveChange(SaveUserChangeRequest req)
        {
            var target = db.User.FirstOrDefault(x => x.Id==req.Id);

            if (target == null)
            {
                throw new Exception("Target User Not Found");
            }

            target.LoginId = req.LoginId;
            target.Name = req.Name;
            target.MailAddress = req.Address;

            db.SaveChanges();
        }

        public GetUserDetailsResponse GetUserDetails(string id)
        {
            var res = db.User.FirstOrDefault(x => x.Id == id);

            return new GetUserDetailsResponse(res.Name, res.MailAddress, res.LoginId);
        }

        public GetUserIdList GetUserIdList()
        {
            var res = db.User.Select(x => x.Id).ToList();
            return new GetUserIdList(res);
        }
    }
}