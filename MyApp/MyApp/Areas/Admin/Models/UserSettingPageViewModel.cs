using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models
{
    public class UserSettingPageViewModel
    {
        public UserSettingPageViewModel(string id, string loginId, string name, string mailAddress)
        {
            Id = id;
            LoginId = loginId;
            Name = name;
            MailAddress = mailAddress;
        }

        public string Id { get; }

        [DataType(DataType.Password)]
        public string LoginId { get; }

        [DataType(DataType.Text)]
        public string Name { get; }

        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; }
    }
}