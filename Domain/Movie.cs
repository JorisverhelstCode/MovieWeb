using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Domain
{
    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public int ID { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
