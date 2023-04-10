﻿namespace VidlyNew.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}
