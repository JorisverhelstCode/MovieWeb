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
        [MinLength(1, ErrorMessage = "De titel heeft een minimum lengte van 1 karakters!")]
        [MaxLength(30, ErrorMessage ="De titel heeft een maximum lengte van 30 karakters!")]
        public String Title { get; set; }

        [DisplayName("Genre")]
        [MinLength(1, ErrorMessage = "Het genre heeft een minimum lengte van 1 karakters!")]
        [MaxLength(20, ErrorMessage = "Het genre heeft een maximum lengte van 20 karakters!")]
        public String Genre { get; set; }

        [MaxLength(30, ErrorMessage = "De omschrijving heeft een maximum lengte van 250 karakters!")]
        [DisplayName("Omschrijving")]
        public String Description { get; set; }

        [Required(ErrorMessage = "De film moet een datum van uitgifte hebben!")]
        [DisplayName("Datum van uitgifte")]
        public DateTime ReleaseDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "De film moet een producent hebben!")]
        [DisplayName("Producent")]
        [MinLength(1, ErrorMessage = "De producent heeft een minimum lengte van 1 karakters!")]
        [MaxLength(20, ErrorMessage = "De producent heeft een maximum lengte van 20 karakters!")]
        public String Producer { get; set; }
    }
}
