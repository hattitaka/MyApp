using MyApp.Areas.Admin.Repository.Models;
using System.Linq;

namespace MyApp.Areas.Admin.Repository
{
    public class TextRepository
    {
        MyAppDBEntities1 db = new MyAppDBEntities1();

        public GetTextResponse GetText(string userId)
        {
            var res = db.Text.FirstOrDefault(x => x.UserId == userId);

            if (res == null)
            {
                return new GetTextResponse();
            }

            return new GetTextResponse(res.Title, res.Description, res.Profile_1);
        }

        public void SaveText(RegisterTextRequest req)
        {
            var target = db.Text.FirstOrDefault(x => x.UserId == req.UserId);
            target.Title = req.Title;
            target.Description = req.Description;
            target.Profile_1 = req.Profile_1;

            db.SaveChanges();
        }
    }
}