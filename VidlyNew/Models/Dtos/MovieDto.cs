using System.ComponentModel.DataAnnotations;

namespace VidliNew.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int GenreId { get; set; }
        public GenreDto Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public byte NumberInStock { get; set; }

    }
}
