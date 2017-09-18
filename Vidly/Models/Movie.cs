using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public Genres GenreId { get; set; }
        public DateTime DateAdded { get; set; } 
        public DateTime RelesaseDate { get; set; }
        public int StockNumber { get; set; }    
    }
}