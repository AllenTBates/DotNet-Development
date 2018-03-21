using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieService.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        // Foreign Key
        public int DirectorId { get; set; }
        // Navigation property
        public Director Director { get; set; }
    }
}