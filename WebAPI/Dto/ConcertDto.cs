using WebAPI.Models;
using WebAPI.Models.Junctions;

namespace WebAPI.Dto
{
    public class ConcertDto
    {
        public int ConcertId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public float Price { get; set; }
        public string[] Genre { get; set; }


        public ICollection<Show> Show { get; set; }
        //public ICollection<ConcertGenres> ConcertGenres { get; set; }
    }
}
