using MyApp.Areas.Admin.Models.Models;

namespace MyApp.Areas.Admin.Models.UserCase.GetContent
{
    public class GetContentResponse: ResponseBase
    {
        public GetContentResponse(Content source)
        {
            Title = source.Title;
            Description = source.Decription;
            Profiles = source.Plofiles;
        }

        public GetContentResponse(string errorMessage)
            : base(errorMessage) { }

        public GetContentResponse() { }

        public string Title { get; }

        public string Description { get; }

        public string Profiles { get; }
    }
}