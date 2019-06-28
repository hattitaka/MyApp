using MyApp.Areas.Admin.Models.Models;
using MyApp.Areas.Admin.Models.UserCase.ChangeContent;
using MyApp.Areas.Admin.Models.UserCase.GetContent;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Areas.Admin.Models.Repository
{
    public class InMemoryContentRepository : IContentRepository
    {
        private List<Content> data = new List<Content>()
        {
            new Content()
            {
                Id = "test1",
                UserId = "userId1",
                Title = "This is Title_1",
                Decription = "This is Description_1",
                Plofiles = "This is Profiles_1",
            },
            new Content()
            {
                Id = "test2",
                UserId = "userId2",
                Title = "This is Title_2",
                Decription = "This is Description_2",
                Plofiles = "This is Profiles_2",
            }
        };


        public ChangeContentResponse ChengeContent(ChangeContentRequest req)
        {
            var target = data.FirstOrDefault(x => x.UserId == req.UserId);

            if (target == null)
            {
                return new ChangeContentResponse("Invalid request");
            }

            target.Title = req.Title;
            target.Decription = req.Description;
            target.Plofiles = req.Profiles;

            return new ChangeContentResponse(target.Title, target.Decription, target.Plofiles);
        }

        public GetContentResponse GetContent(GetContentRequest req)
        {
            var target = data.FirstOrDefault(x => x.UserId == req.UserId);

            if (target == null)
            {
                return new GetContentResponse("Invalid request");
            }

            return new GetContentResponse(target);
        }
    }
}