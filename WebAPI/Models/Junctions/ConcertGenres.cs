namespace WebAPI.Models.Junctions
{
    public class ConcertGenres
    {

        public int ConcertId { get; set; }
        
        public int GenreId { get; set; }


        public Concert Concert { get; set; }

        public Genre Genre { get; set; }

    }
}
