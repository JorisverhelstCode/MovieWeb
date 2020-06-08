using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Models
{
    public class MovieCreateViewModel
    {
        public String Title { get; set; }
        public String Genre { get; set; }
        public String Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Producer { get; set; }
    }
}
