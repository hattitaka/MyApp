using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Models.Contexts;
using MyApp.Areas.Admin.Models.Models;
using MyApp.Areas.Admin.Models.UserCase.ChangeUserInfo;
using MyApp.Areas.Admin.Models.UserCase.CheckUser;
using MyApp.Areas.Admin.Models.UserCase.CreateUser;
using MyApp.Areas.Admin.Models.UserCase.GetUserDetails;
using MyApp.Areas.Admin.Models.UserCase.GetUserSummaries;
using System.Linq;
using System.Web.Configuration;

namespace MyApp.Areas.Admin.Models.Repository
{
    public class UserRepository: IUserRepository
    {
        private BasicContext db = new BasicContext();

        public GetUserDetailsResponse GetUserDetails (GetUserDetailsRequest req)
        {
            var target = db.Users.Find(req.UserId);

            if(target == null)
            {
                var errorMessage = "user is not found";
                return new GetUserDetailsResponse(errorMessage);
            }

            return new GetUserDetailsResponse(target);
        }

        public ChangeUserInfoResponse ChangeUserInfo(ChangeUserInfoRequest req)
        {
            var target = db.Users.Find(req.Id);

            if (target == null)
            {
                throw new System.Exception("Invalid request");
            }

            target.Name = req.Name;
            target.MailAddress = req.MailAddress;
            target.Password = req.Password;

            db.SaveChanges();

            return new ChangeUserInfoResponse(target.Name, target.MailAddress, target.Password);
        }

        public CheckUserResponse CheckUser(CheckUserRequest req)
        {
            var target = db.Users.FirstOrDefault(x => x.LoginId == req.LoginId && x.Password == req.Password);

            if (target == null)
            {
                return new CheckUserResponse();
            }

            return new CheckUserResponse(target.Id);
        }

        public GetUserSummariesResponse GetUserSummaries()
        {
            var summaries = db.Users
                .Select(x => new UserSummary() { Id = x.Id, Name = x.Name })
                .ToList();

            return new GetUserSummariesResponse(summaries);
        }

        public CreateUserResponse CreateUser(CreateUserRequest req)
        {
            // User
            var user = UserFactory.Create(req.LoginId, req.Name, req.MailAddress, req.MailAddress);

            // 登録処理は以下に記述する
            db.Users.Add(user);
            db.SaveChanges();

            return new CreateUserResponse(user.Name, user.LoginId, user.Password, user.MailAddress);

            // throw new System.NotImplementedException();
        }
    }
}