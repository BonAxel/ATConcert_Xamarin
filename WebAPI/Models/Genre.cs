namespace WebAPI.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Concert> Concerts { get; set; }
        public Genre(string name)
        {
            Name = name;
            Concerts = new List<Concert>();
        }
    }
}
