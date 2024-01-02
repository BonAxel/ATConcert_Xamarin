using System;
using System.Collections.Generic;
using System.Text;
using ATConcert.Models.Junctions;

namespace ATConcert.Models
{
    public class Concert
    {
        public int ConcertId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
        //public ICollection<ConcertGenres> ConcertGenres { get; set; }
        //public ICollection<Show> Shows { get; set; }
    }
}
