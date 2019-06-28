using MyApp.Areas.Admin.Models.UserCase.ChangeContent;
using MyApp.Areas.Admin.Models.UserCase.GetContent;

namespace MyApp.Areas.Admin.Models.Repository
{
    public interface IContentRepository
    {
        GetContentResponse GetContent(GetContentRequest req);

        ChangeContentResponse ChengeContent(ChangeContentRequest req);
    }
}
