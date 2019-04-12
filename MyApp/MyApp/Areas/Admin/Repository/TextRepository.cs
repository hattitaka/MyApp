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

        public GetTextResponse GetText(string userId)
        {
            // 渡されたuerIdをもとにTextテーブル内を検索する
            var res = db.Text.FirstOrDefault(x => x.UserId == userId);

            // 検索結果がNullなら空レスポンス
            if (res == null)
            {
                return new GetTextResponse();
            }

            // 検索結果が存在すれば取得したデータを返す
            return new GetTextResponse(res.Title, res.Description, res.Profile_1);
        }

    }
}