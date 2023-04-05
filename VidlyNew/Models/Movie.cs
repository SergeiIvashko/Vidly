using System.ComponentModel.DataAnnotations;

namespace Vidli.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }

        public DateTime DateAdded { get; set; }
        
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}
