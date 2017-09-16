using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie() {Id = 1, Name = "A Dog's Purpose"},
                new Movie() {Id = 2, Name = "Interstaller"}
            };
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