using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MoviesController(ApplicationDBContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Movies 
        public IActionResult Index(int? pageIndex, string sortBy)
        {
            IEnumerable<Movie> Movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(Movies);
        }


        public IActionResult Edit(int id)
        {
            Movie found = _context.Movies.Include(m => m.Genre).FirstOrDefault(c => c.Id == id);
            if (found == null)
                return NotFound();
            else
            {
                MovieFormViewModel viewModel = new MovieFormViewModel
                {
                    Movie = found,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

        }

        public IActionResult New()
        {
            MovieFormViewModel viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now.Date;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.First(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumInStock = movie.NumInStock;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Route("movies/released/{year}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}