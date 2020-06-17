using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Domain
{
    public class MovieTag
    {
        public Movie Movie { get; set; }
        public int MovieID { get; set; }
        public Tag Tag { get; set; }
        public int TagID { get; set; }
    }
}
