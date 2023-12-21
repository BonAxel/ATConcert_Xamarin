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
        public  static void SeedDataContext(DataContext _context)
        {

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.Shows.Add(new Show
            {
                Venue = "Venue 1",
                DateTime = DateTime.Now,
                Concert =
                new Concert
                {
                    Title = "Slipknot",
                    Price = 130,
                    Length = 180,
                    Description = "Slipknow finaly arrives to Sweden, get your tickets now",
                    ConcertGenres = new List<ConcertGenres>()
                    {
                       new ConcertGenres { Genre = new Genre { Name = "Rock"}
                    }
                }
                }
            });
            _context.Shows.Add(new Show
            {
                Venue = "Venue 2",
                DateTime = DateTime.Now,
                Concert =
                new Concert
                {
                    Title = "Florence & The Machine",
                    Price = 150,
                    Length = 200,
                    Description = "England baseed Florence & The Machines arrives to Sweden, get your tickets now",
                    ConcertGenres = new List<ConcertGenres>()
                    {
                        new ConcertGenres {Genre = new Genre { Name = "Indie" } }

                    }
                },
            });
            _context.SaveChanges();

        }
    }
}