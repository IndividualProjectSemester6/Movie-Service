namespace MoviesService.API.Models
{
    public class CreateMovieViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateMovieViewModel()
        {
        }

        public CreateMovieViewModel(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
