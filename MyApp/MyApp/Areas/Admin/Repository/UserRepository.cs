using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Repository.Models;
using System;
using System.Linq;

namespace MyApp.Areas.Admin.Repository
{
    public class UserRepository: IUserRepository
    {
        private DataBaseEntities db = new DataBaseEntities();

        public CheckUserResponse CheckUser(CheckUserRequest req)
        {
            var target = db.User.FirstOrDefault(x => x.LoginId == req.LoginId && x.Password == req.Password);

            if (target == null)
            {
                return null;
            }

            return new CheckUserResponse(target.Id, target.Name, target.MailAddress);
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

        public GetUserListResponse GetUserList()
        {
            var res = db.User
                .Select(x => new UserItem() { Id = x.Id, Name = x.Name })
                .ToList();
            return new GetUserListResponse(res);
        }
    }
}