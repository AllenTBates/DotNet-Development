using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieService.Models
{
    public class MovieDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string DirectorName { get; set; }
        public string Genre { get; set; }
    }
}