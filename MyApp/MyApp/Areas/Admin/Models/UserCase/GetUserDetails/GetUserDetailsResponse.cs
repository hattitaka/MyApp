using MyApp.Areas.Admin.Models.Models;

namespace MyApp.Areas.Admin.Models.UserCase.GetUserDetails
{
    public class GetUserDetailsResponse: ResponseBase
    {
        public GetUserDetailsResponse(User source)
        {
            Id = source.Id;
            Name = source.Name;
            LoginId = source.LoginId;
            Password = source.Password;
            MailAddress = source.MailAddress;
        }

        public GetUserDetailsResponse(string errorMessage)
            :base(errorMessage){ }

        public string Id { get; }

        public string Name { get; }

        public string LoginId { get; }

        public string Password { get; }

        public string MailAddress { get; }
    }
}