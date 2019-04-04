using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.InDataBaseInfrastructure
{
    public class TextRepository
    {
        private MyAppDBEntities data = new MyAppDBEntities();

        public AllText GetAll(int userId)
        {
            var text = data.Text.FirstOrDefault(x => x.UserId == userId);

            return new AllText(text.Title, text.Description, text.Profile_1);
        }

        public void SaveAll(AllText text, int userId)
        {
            var target = data.Text.FirstOrDefault(x => x.UserId == userId);

            target.Title = text.Title;
            target.Description = text.Description;
            target.Profile_1 = text.Profile_1;

            data.SaveChanges();
        }
    }
}