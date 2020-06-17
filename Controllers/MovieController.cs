using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWeb.Controllers.MovieWeb.Database;
using MovieWeb.Database;
using MovieWeb.Domain;
using MovieWeb.Models;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieDatabase _movieDatabase;
        private readonly MovieDBContext _movieDBContext;

        public MovieController(IMovieDatabase movieDatabase, MovieDBContext context)
        {
            _movieDatabase = movieDatabase;
            _movieDBContext = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> moviesFromDb = await _movieDBContext.Movies.ToListAsync();
            List<MovieListViewModel> movies = new List<MovieListViewModel>();
            foreach (Movie movie in moviesFromDb)
            {
                movies.Add(new MovieListViewModel() { ID = movie.ID, Title = movie.Title });
            }
            return View(movies);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Movie movieFromDb = await _movieDBContext.Movies.FindAsync(id);
            MovieDetailsViewModel movie = new MovieDetailsViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate,
                Genre = movieFromDb.Genre,
                Producer = movieFromDb.Producer,
                ID = movieFromDb.ID
            };
            return View(movie);
        }

        public IActionResult Create()
        {
            MovieCreateViewModel vm = new MovieCreateViewModel();
            vm.ReleaseDate = DateTime.Now;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel movie)
        {
            if (!TryValidateModel(movie))
            {
                return View(movie);
            } else
            {
                Movie newMovie = new Movie()
                {
                    Title = movie.Title,
                    Genre = movie.Genre,
                    Description = movie.Description,
                    Producer = movie.Producer,
                    ReleaseDate = movie.ReleaseDate
                };

                _movieDBContext.Movies.Add(newMovie);
                _movieDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            Movie movieFromDb = await _movieDBContext.Movies.FindAsync(id);
            MovieEditViewModel editView = new MovieEditViewModel()
            {
                Title = movieFromDb.Title,
                Genre = movieFromDb.Genre,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate,
                Producer = movieFromDb.Producer
            };
            return View(editView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MovieEditViewModel movie)
        {
            if (!TryValidateModel(movie))
            {
                return View(movie);
            }
            else
            {
                Movie movieFromDb = await _movieDBContext.Movies.FindAsync(id);
                movieFromDb.Title = movie.Title;
                movieFromDb.Genre = movie.Genre;
                movieFromDb.Description = movie.Description;
                movieFromDb.Producer = movie.Producer;
                movieFromDb.ReleaseDate = movie.ReleaseDate;

                _movieDBContext.Movies.Update(movieFromDb);
                _movieDBContext.SaveChanges();
                return RedirectToAction("Detail", new { id = id });
            }
        }

        public async Task<IActionResult> Delete(int id, string returnUrl)
        {
            Movie movieFromDb = await _movieDBContext.Movies.FindAsync(id);
            MovieDeleteViewModel deleteView = new MovieDeleteViewModel()
            {
                Title = movieFromDb.Title,
                ID = movieFromDb.ID,
                ReturnUrl = returnUrl
            };
            return View(deleteView);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(MovieDeleteViewModel deleteModel)
        {
            Movie movieFromDb = await _movieDBContext.Movies.FindAsync(deleteModel.ID);
            _movieDBContext.Movies.Remove(movieFromDb);
            _movieDBContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}