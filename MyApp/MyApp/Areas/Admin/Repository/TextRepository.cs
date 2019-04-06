using MyApp.Areas.Admin.Repository.Models.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Repository
{
    public class TextRepository
    {
        private MyAppDBEntities db = new MyAppDBEntities();

        public void GetText(GetTextRequest req)
        {
            var res = db.Text.FirstOrDefault(x => x.UserId==req.UserId);
        }
    }
}