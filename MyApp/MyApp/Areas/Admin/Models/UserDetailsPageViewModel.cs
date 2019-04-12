using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Areas.Admin.Models
{
    public class UserDetailsPageViewModel
    {
        public UserDetailsPageViewModel(string loginId, string name, string mailAddress)
        {
            LoginId = loginId;
            Name = name;
            MailAddress = mailAddress;
        }

        [DataType(DataType.Password)]
        public string LoginId { get; }

        [DataType(DataType.Text)]
        public string Name { get; }

        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; }
    }
}