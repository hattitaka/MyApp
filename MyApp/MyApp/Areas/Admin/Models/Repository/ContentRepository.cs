using MyApp.Areas.Admin.Models.Contexts;
using MyApp.Areas.Admin.Models.Models;
using MyApp.Areas.Admin.Models.UserCase.ChangeContent;
using MyApp.Areas.Admin.Models.UserCase.GetContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models.Repository
{
    public class ContentRepository: IContentRepository
    {
        private BasicContext db = new BasicContext();

        public GetContentResponse GetContent(GetContentRequest req)
        {
            var target = db.Contents.FirstOrDefault(x => x.UserId == req.UserId);

            if(target == null)
            {
                return new GetContentResponse("Invalid request");
            }

            return new GetContentResponse(target);
        }

        public ChangeContentResponse ChengeContent(ChangeContentRequest req)
        {
            var target = db.Contents.Find(new Content() { UserId = req.UserId });

            if(target == null)
            {
                return new ChangeContentResponse("Invalid request");
            }

            target.Title = req.Title;
            target.Decription = req.Description;
            target.Plofiles = req.Profiles;

            db.SaveChanges();

            return new ChangeContentResponse(target.Title, target.Decription, target.Plofiles);
        }
    }
}