using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Models
{
    public class MovieCreateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "De film moet een titel hebben!")]
        [DisplayName("Titel")]
        [MaxLength(30, ErrorMessage ="De titel heeft een maximum lengte van 30 karakters!")]
        public String Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "De film moet een genre hebben!")]
        [DisplayName("Genre")]
        public String Genre { get; set; }

        [DisplayName("Omschrijving")]
        public String Description { get; set; }

        [Required(ErrorMessage = "De film moet een datum van uitgifte hebben!")]
        [DisplayName("Datum van uitgifte")]
        public DateTime ReleaseDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "De film moet een producent hebben!")]
        [DisplayName("Producent")]
        public String Producer { get; set; }
    }
}
