﻿using WebAPI.Models.Junctions;

namespace WebAPI.Models
{
    public class Concert
    {
        public int ConcertId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public float Price { get; set; }

        public ICollection<ConcertGenres> ConcertGenres { get; set; }
        //public ICollection<Show> Shows { get; set; }
        
      
    }
}
