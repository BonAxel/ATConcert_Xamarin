using WebAPI.Models;
using WebAPI.Models.Junctions;

namespace WebAPI.Data.Seed
{
    public class Seed
    {
        //private readonly DataContext _context;
        //public Seed(DataContext context)
        //{
        //    _context = context;
        //}
        public static void SeedDataContext(DataContext _context)
        {

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Concerts.Add(new Concert
            {
                Title = "Slipknot",
                Price = 130,
                Genre = ["Rock", "Metal"],
                Length = 180,
                Description = "Slipknot finaly arrives to Sweden, get your tickets now",
                Show = new List<Show>() { new Show
                {
                    Venue = "Ullevi i Göteborg",
                    DateTime = new DateTime(2024,01,02,12,0,0),

                }, new Show{

                    Venue = "Friends Arena i Stockholm",
                    DateTime = new DateTime(2024,01,05,12,0,0),} },

                ConcertGenres = new List<ConcertGenres>()
                    {
                       new ConcertGenres { Genre = new Genre { Name = "Rock"}
                    }
                },
            });
            _context.Concerts.Add(new Concert
            {
                Title = "Florence & The Machine",
                Price = 100,
                Genre = ["Indie","Pop"],
                Length = 200,
                Description = "England based Florence & The Machines arrives to Sweden, get your tickets now",
                Show = new List<Show>() { new Show
                {
                    Venue = "Ullevi i Göteborg",
                    DateTime = new DateTime(2024,01,20,12,0,0),

                }, new Show{

                    Venue = "Ullevi i Göteborg",
                    DateTime = new DateTime(2024,01,22,12,0,0),} },

                ConcertGenres = new List<ConcertGenres>()
                    {
                       new ConcertGenres { Genre = new Genre { Name = "Indie Pop"}
                    }
                },
            });
            _context.Concerts.Add(new Concert
            {
                Title = "Eminem",
                Price = 160,
                Genre = ["Rap"],
                Length = 200,
                Description = "Famous Rap artist Eminem comes to Sweden. Get your tickets now!",
                Show = new List<Show>() { new Show
                {
                    Venue = "Ullevi i Göteborg",
                    DateTime = new DateTime(2024,02,10,12,0,0),

                },new Show
                {
                    Venue = "Ullevi i Göteborg",
                    DateTime = new DateTime(2024,01,11,12,0,0),

                },new Show
                {
                    Venue = "Ullevi i Göteborg",
                    DateTime = new DateTime(2024,01,14,12,0,0),

                },
                    new Show{

                    Venue = "Friends Arena i Stockholm",
                    DateTime = DateTime.Now,} },

                ConcertGenres = new List<ConcertGenres>()
                    {
                       new ConcertGenres { Genre = new Genre { Name = "Rap"}
                    }
                },
            });
            _context.SaveChanges();

        }
    }
}