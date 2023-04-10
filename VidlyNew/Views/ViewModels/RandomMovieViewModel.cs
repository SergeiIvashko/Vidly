using VidlyNew.Models;

namespace VidlyNew.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}
