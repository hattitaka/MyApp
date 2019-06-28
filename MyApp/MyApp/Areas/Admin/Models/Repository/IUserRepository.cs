using MyApp.Areas.Admin.Models.UserCase.ChangeUserInfo;
using MyApp.Areas.Admin.Models.UserCase.CheckUser;
using MyApp.Areas.Admin.Models.UserCase.CreateUser;
using MyApp.Areas.Admin.Models.UserCase.GetUserDetails;
using MyApp.Areas.Admin.Models.UserCase.GetUserSummaries;

namespace MyApp.Areas.Admin.Models.Repository
{
    public interface IUserRepository
    {
        GetUserDetailsResponse GetUserDetails(GetUserDetailsRequest req);

        ChangeUserInfoResponse ChangeUserInfo(ChangeUserInfoRequest req);

        CheckUserResponse CheckUser(CheckUserRequest req);

        GetUserSummariesResponse GetUserSummaries();

        CreateUserResponse CreateUser(CreateUserRequest req);
    }
}
