using MovieWeb.Domain;
using MovieWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieWeb.Controllers
{
    namespace MovieWeb.Database
    {
        public interface IMovieDatabase
        {
            Movie Insert(Movie movie);
            IEnumerable<Movie> GetMovies();
            Movie GetMovie(int id);
            void Delete(int id);
            void Update(int id, Movie movie);
        }

        public class MovieDatabase : IMovieDatabase
        {
            private int _counter;
            private readonly List<Movie> _movies;

            public MovieDatabase()
            {
                if (_movies == null)
                {
                    _movies = new List<Movie>();
                    LoadFullMovies();
                }
            }

            public Movie GetMovie(int id)
            {
                return _movies.FirstOrDefault(x => x.ID == id);
            }

            public IEnumerable<Movie> GetMovies()
            {
                return _movies;
            }

            public Movie Insert(Movie movie)
            {
                _counter++;
                movie.ID = _counter;
                _movies.Add(movie);
                return movie;
            }

            public void Delete(int id)
            {
                var movie = _movies.SingleOrDefault(x => x.ID == id);
                if (movie != null)
                {
                    _movies.Remove(movie);
                }
            }

            public void Update(int id, Movie updatedMovie)
            {
                var movie = _movies.SingleOrDefault(x => x.ID == id);
                if (movie != null)
                {
                    movie.Title = updatedMovie.Title;
                    movie.Description = updatedMovie.Description;
                    movie.ReleaseDate = updatedMovie.ReleaseDate;
                    movie.Genre = updatedMovie.Genre;
                }
            }

            public void LoadFullMovies()
            {
                Movie lionking = new Movie()
                {
                    Producer = "Disney",
                    Title = "The lion king",
                    Description = "A film about a young lion growing up to become the king of his pack",
                    ReleaseDate = new DateTime(1995, 5, 6),
                    Genre = "Animation"
                };
                _movies.Add(lionking);

                Movie fellowship = new Movie()
                {
                    Producer = "Peter Jackson",
                    Title = "The fellowship of the ring",
                    Description = "The felowship departs the shire and starts their adventure through middle earth",
                    ReleaseDate = new DateTime(2001, 3, 6),
                    Genre = "Fantasy"
                };
                _movies.Add(fellowship);

                Movie twotowers = new Movie()
                {
                    Producer = "Peter Jackson",
                    Title = "The two towers",
                    Description = "The fellowship faces difficult foes while onn their way to mordor",
                    ReleaseDate = new DateTime(2002, 9, 4),
                    Genre = "Fantasy"
                };
                _movies.Add(twotowers);

                Movie returnking = new Movie()
                {
                    Producer = "Peter Jackson",
                    Title = "The lion king",
                    Description = "A film about a young lion growing up to become the king of his pack",
                    ReleaseDate = new DateTime(2004, 2, 26),
                    Genre = "Fantasy"
                };
                _movies.Add(returnking);
            }
        }
    }
}