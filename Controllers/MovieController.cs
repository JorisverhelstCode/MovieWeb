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

                _movieDatabase.Insert(newMovie);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);
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
        public IActionResult Edit(int id, MovieEditViewModel movie)
        {
            if (!TryValidateModel(movie))
            {
                return View(movie);
            }
            else
            {
                Movie edittedMovie = new Movie()
                {
                    Title = movie.Title,
                    Genre = movie.Genre,
                    Description = movie.Description,
                    Producer = movie.Producer,
                    ReleaseDate = movie.ReleaseDate
                };

                _movieDatabase.Update(id, edittedMovie);
                return RedirectToAction("Detail", new { id = id });
            }
        }

        public IActionResult Delete(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);
            MovieDeleteViewModel deleteView = new MovieDeleteViewModel()
            {
                Title = movieFromDb.Title,
                ID = movieFromDb.ID
            };
            return View(deleteView);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id, bool confirmed)
        {
            if (confirmed)
            {
                _movieDatabase.Delete(id);
                return RedirectToAction("Index");
            } else
            {
                return RedirectToAction("Detail", new { id = id } );
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