using MyApp.Areas.Admin.Models.Models;

namespace MyApp.Areas.Admin.Models.UserCase.GetUserDetails
{
    public class GetUserDetailsRequest
    {
        public GetUserDetailsRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}