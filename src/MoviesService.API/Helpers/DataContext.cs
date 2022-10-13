using Microsoft.EntityFrameworkCore;

namespace MoviesService.API.Helpers
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext()
        {
        }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }
    }
}
