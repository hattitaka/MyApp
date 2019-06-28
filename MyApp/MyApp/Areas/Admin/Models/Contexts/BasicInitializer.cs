using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Models.Models;
using System.Data.Entity;

namespace MyApp.Areas.Admin.Models.Contexts
{
    public class BasicInitializer : CreateDatabaseIfNotExists<BasicContext>
    {
        // 「4.3 イニシャライザー作成.txt」
        /* --------------------------------------------- */
        protected override void Seed(BasicContext context)
        {
            var testAccount = UserFactory.Create(
                "TEST",
                "TEST",
                "test@gmo.com",
                "TEST"
                );
            context.Users.Add(testAccount);

            var testContent = new Content()
            {
                Id = IdFactory.Generate(),
                UserId = testAccount.Id,
                Title = "TEST TITLE",
                Decription = "TEST DESCRIPTION",
                Plofiles = "PROFILE",
            };
            context.Contents.Add(testContent);

            context.SaveChanges();
        }
        /* --------------------------------------------- */
    }
}