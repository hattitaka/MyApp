using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Models;
using MyApp.Areas.Admin.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository
{
    public class TextRepository
    {
        MyAppDBEntities db = new MyAppDBEntities();

        public void RegistText(RegisterTextRequest req)
        {
            var target = db.Text.FirstOrDefault(x => x.UserId == req.UserId);
            target.Title = req.Title;
            target.Description = req.Description;
            target.Profile_1 = req.Profile_1;

            db.SaveChanges();
        }
    }
}