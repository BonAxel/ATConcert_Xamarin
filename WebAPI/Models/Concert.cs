namespace WebAPI.Models
{
    public class Concert
    {
        public int ConcertId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public float Price { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<Show> Shows { get; set; }
        public Concert(string title, string description, int length, float price, List<Genre> genres, List<Show> shows)
        {
            Title = title;
            Description = description;
            Length = length;
            Price = price;
            Genres = genres;
            Shows = shows;

        }
    }
}
