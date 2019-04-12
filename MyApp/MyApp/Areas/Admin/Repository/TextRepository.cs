using MyApp.Areas.Admin.Repository.Models;
using System.Linq;

namespace MyApp.Areas.Admin.Repository
{
    public class TextRepository
    {
        DataBaseEntities db = new DataBaseEntities();

        public void SaveText(RegisterTextRequest req)
        {
            var target = db.Text.FirstOrDefault(x => x.UserId == req.UserId);
            target.Title = req.Title;
            target.Description = req.Description;
            target.Profile_1 = req.Profile_1;

            db.SaveChanges();
        }

        // 「3.1 編集内容の保存アクションを作成する.txt」の中身をこの間にコピー
        /* --------------------- */

        /* --------------------- */
    }
}