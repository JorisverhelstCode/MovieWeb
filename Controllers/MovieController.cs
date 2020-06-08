using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Controllers.MovieWeb.Database;
using MovieWeb.Domain;
using MovieWeb.Models;

namespace MovieWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieDatabase _movieDatabase;

        public MovieController(IMovieDatabase movieDatabase)
        {
            _movieDatabase = movieDatabase;
        }

        public IActionResult Index()
        {
            return View(CreateList());
        }

        public IActionResult Detail(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);
            MovieDetailsViewModel movie = new MovieDetailsViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate,
                Genre = movieFromDb.Genre
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

                _movieDatabase.Insert(newMovie);
                return RedirectToAction("Index");
            }
        }

        public List<MovieListViewModel> CreateList()
        {
            IEnumerable<Movie> moviesFromDb = _movieDatabase.GetMovies();
            List<MovieListViewModel> movies = new List<MovieListViewModel>();
            foreach (Movie movie in moviesFromDb)
            {
                movies.Add(new MovieListViewModel() { ID = movie.ID, Title = movie.Title });
            }
            return movies;
        }
    }
}