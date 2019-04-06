using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin
{
    public class InMemoryPortfolioWordRepositories
    {
        private static Dictionary<string, string> data = new Dictionary<string, string>()
        {
            { "title", "Welcome to my HP!!" },
            { "description", "Sample Portfolio Site" },
            { "profile_1", "大学を卒業後に都内のシステム開発会社に就職し、PC向けのWebアプリケーションの構築やiPhone、Androidなどスマートフォン向けのネイティブアプリの開発などを担当しています。" },
            { "profile_2", "趣味は写真を撮る事で休日に車で色々な所に行き写真を撮影しています。最近は撮った写真の加工やデザイン関係にも興味を持ちシステムのUIデザインなども勉強中です。" }
        };

        public string GetValue(string key)
        {
            if (data.TryGetValue(key, out var value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public AllText GetAll()
        {
            return new AllText(data["title"], data["description"], data["profile_1"]);
        }

        public void Save(SiteText siteText)
        {
            data[siteText.Id] = siteText.Text;
        }

        public void SaveAll(AllText text)
        {
            data["title"] = text.Title;
            data["description"] = text.Description;
            data["profile_1"] = text.Profile_1;
        }
    }
}