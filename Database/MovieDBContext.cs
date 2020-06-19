using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Database
{
    public class MovieDBContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {

        }


    }
}
