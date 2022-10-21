namespace MoviesService.API.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MovieViewModel()
        {
        }

        public MovieViewModel(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
