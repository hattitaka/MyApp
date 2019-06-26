namespace MyApp.Areas.Admin.Models.UserCase
{
    public class ResponseBase
    {
        public ResponseBase(string errorMessage = null)
        {
            HasError = !(errorMessage == null);
            ErrorMessage = errorMessage;
        }

        public bool HasError { get; }

        public string ErrorMessage { get; }
    }
}