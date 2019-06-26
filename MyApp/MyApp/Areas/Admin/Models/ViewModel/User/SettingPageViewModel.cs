using System.ComponentModel.DataAnnotations;

namespace MyApp.Areas.Admin.Models.ViewModel.User
{
    public class SettingPageViewModel
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }
    }
}