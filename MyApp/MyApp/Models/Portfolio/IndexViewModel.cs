namespace MyApp.Models.Portfolio
{
    public class IndexViewModel
    {
        public IndexViewModel(string title, string description, string profiles)
        {
            Title = title;
            Description = description;
            Profiles = profiles;
        }

        public string Title { get; }

        public string Description { get; }

        public string Profiles { get; }
    }
}