using System;
using System.Collections.Generic;
using System.Text;
using ATConcert.Models.Junctions;

namespace ATConcert.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<ConcertGenres> ConcertGenres { get; set; }

    }
}
