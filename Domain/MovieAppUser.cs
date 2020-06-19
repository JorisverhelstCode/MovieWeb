using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Domain
{
    public class MovieAppUser : IdentityUser
    {
        public string Geslacht { get; set; }
    }
}
