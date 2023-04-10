using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyNew.Data;
using VidlyNew.Models;
using VidlyNew.ViewModels;

namespace Vidli.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList();
            
            if (User.IsInRole(RoleName.Admin))
            {

                return View("List", movie);
            }

            return View("ReadOnlyList", movie);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormModel
            {
                Genres = genres,
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var genre = _context.Genres.Single(g => g.Id == movie.GenreId);
            movie.Genre = genre;

            var viewModel = new MovieFormModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormModel(movie)
                {
                    Genres = _context.Genres.ToList(),
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie); 
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [AllowAnonymous]
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
 
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}
