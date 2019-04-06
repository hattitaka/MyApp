using MyApp.Areas.Admin.Repository.Models;
using MyApp.Areas.Admin.Repository.Models.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository
{
    public class UserRepository
    {
        private MyAppDBEntities db = new MyAppDBEntities();

        public GetUserResponse GetUser(GetUserRequest req)
        {
            var res = db.User.FirstOrDefault(x => x.LoginId==req.LoginId && x.Address==req.MailAddress );

            if(res != null)
            {
                return new GetUserResponse(res.Id, res.Name, res.Address, res.LoginId);
            }

            return new GetUserResponse();
        }
    }
}