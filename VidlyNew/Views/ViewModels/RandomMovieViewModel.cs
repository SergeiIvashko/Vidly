using Vidli.Models;

namespace Vidli.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}
