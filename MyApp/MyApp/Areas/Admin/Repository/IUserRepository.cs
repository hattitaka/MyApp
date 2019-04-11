using MyApp.Areas.Admin.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Areas.Admin.Repository
{
    /// <summary>
    /// インターフェース
    /// クラスが実装するべきもの(メソッドや引数)を定義することができます
    /// 下記であるとUserにまつわるクラス(UserRepositoryとInMemoryUserRepositories)が実装するべきメソッドを定義しています。
    /// </summary>
    interface IUserRepository
    {
        CheckUserResponse CheckUser(CheckUserRequest req);

        void RegisterUser(RegisterUserRequest req);

        void SaveChange(SaveUserChangeRequest req);

        GetUserDetailsResponse GetUserDetails(string id);

        GetUserListResponse GetUserList();
    }
}
