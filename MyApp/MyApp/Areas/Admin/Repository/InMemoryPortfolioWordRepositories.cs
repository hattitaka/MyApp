using MyApp.Areas.Admin.Repository.Models;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin
{
    public class InMemoryPortfolioWordRepositories
    {
        private static IEnumerable<AllText> testData = new List<AllText>
        {
            new AllText("asdfadsfasdf", "Welcome to my HP!!", "Sample Portfolio Site", "大学を卒業後に都内のシステム開発会社に就職し、PC向けのWebアプリケーションの構築やiPhone、Androidなどスマートフォン向けのネイティブアプリの開発などを担当しています。"),
            new AllText("asdfasdf", "Hello", "This is aaa's Site", "趣味は写真を撮る事で休日に車で色々な所に行き写真を撮影しています。最近は撮った写真の加工やデザイン関係にも興味を持ちシステムのUIデザインなども勉強中です。"),
            new AllText("qweoijfa", "Title_3", "this is test site", "無趣味"),
            new AllText("4a9g8jha", "Title_4", "hugahuga", "テキストテキストテキストテキスト"),
            new AllText("agh489pahdag", "Title_5", "hogehoge", "趣味は映画鑑賞"),
        };

        public GetTextResponse GetText(string userId)
        {
            var res = testData.FirstOrDefault(x => x.UserId==userId);

            if(res == null)
            {
                return new GetTextResponse();
            }

            return new GetTextResponse(res.Title, res.Description, res.Profile_1);
        }

        public void SaveText(RegisterTextRequest req)
        {
            var target = testData.FirstOrDefault(x => x.UserId==req.UserId);
            target.Title = req.Title;
            target.Description = req.Description;
            target.Profile_1 = req.Profile_1;
        }
    }
}