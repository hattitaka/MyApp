using MyApp.Areas.Admin.Models.Models;

namespace MyApp.Areas.Admin.Models.UserCase.CheckUser
{
    public class CheckUserResponse: ResponseBase
    {
        public CheckUserResponse(string id)
        {
            Id = id;
        }

        public CheckUserResponse() { }

        public string Id { get; }
    }
}