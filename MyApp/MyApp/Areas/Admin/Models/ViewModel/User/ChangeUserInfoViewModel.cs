namespace MyApp.Areas.Admin.Models.ViewModel.User
{
    public class SaveUserChangeRequestModel
    {
        public string Password { get; set; }

        public string Name { get; set; }

        public string MailAddress { get; set; }
    }
}