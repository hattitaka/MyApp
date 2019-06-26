using MyApp.Areas.Admin.Common;
using MyApp.Areas.Admin.Models.Models;
using MyApp.Areas.Admin.Models.Service;
using System.Data.Entity;

namespace MyApp.Areas.Admin.Models.Contexts
{
    public class BasicInitializer: DropCreateDatabaseAlways<BasicContext>
    {
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
                Plofiles = "PROFILE_1",
            };
            context.Contents.Add(testContent);

            context.SaveChanges();
        }
    }
}