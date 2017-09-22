using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.GenreId).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.GenreId).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);

        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
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
                movie.StockNumber = movie.StockNumber;
                movieInDb.RelesaseDate = movie.RelesaseDate;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
                throw;
            }
            

            return RedirectToAction("Index", "Movies");
        }
    }



    //    public ActionResult Random()
    //    {
    //        var movie = new Movie() { Name = "Shrek!" };
    //        //return View(movie);
    //        //return Content("Hello World");
    //        //return HttpNotFound();
    //        //return new EmptyResult();
    //        var customer = new List<Customer>
    //        {
    //            new Customer {Name = "Elton", Id = 1},
    //            new Customer {Name = "Another Customer", Id = 2}

    //        };

    //        var viewModel = new RandomMovieViewModel
    //        {
    //            Movie = movie,
    //            Customers = customer
    //        };
    //        return View(viewModel);
    //    }

    //    public ActionResult Edit(int id)
    //    {
    //        return Content("id: " + id);
    //    }
        
    //    // movies
    //    public ActionResult Index(int? pageIndex, string sortBy)
    //    {
    //        if (!pageIndex.HasValue)
    //            pageIndex = 1;

    //        if (String.IsNullOrWhiteSpace(sortBy))
    //            sortBy = "Name";

    //        return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
    //    }

    //    [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
    //    public ActionResult ByReleaseDate(int year, int month)
    //    {
    //        return Content(year + "/" + month);
    //    }
    //}
}