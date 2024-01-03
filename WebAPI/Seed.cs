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
                Genre = "Rock",
                Length = 180,
                Description = "Slipknot finaly arrives to Sweden, get your tickets now",
                Show = new List<Show>() { new Show
                {
                    Venue = "Venue 1",
                    DateTime = DateTime.Now,

                }, new Show{

                    Venue = "Venue 2",
                    DateTime = DateTime.Now,} },

                ConcertGenres = new List<ConcertGenres>()
                    {
                       new ConcertGenres { Genre = new Genre { Name = "Rock"}
                    }
                }
            });
            //_context.Shows.Add(new Show
            //{
            //    Venue = "Venue 2",
            //    DateTime = DateTime.Now,
            //    Concert =
            //    new Concert
            //    {
            //        Title = "Florence & The Machine",
            //        Price = 150,
            //        Length = 200,
            //        Genre = "Indie",
            //        Description = "England baseed Florence & The Machines arrives to Sweden, get your tickets now",
            //        ConcertGenres = new List<ConcertGenres>()
            //        {
            //            new ConcertGenres {Genre = new Genre { Name = "Indie" } }
            //        }
            //    },
            //});
            _context.SaveChanges();

        }
    }
}