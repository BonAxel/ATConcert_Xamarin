using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class ShowRepository : IShowRepository
    {
        private readonly DataContext _context;

        public ShowRepository(DataContext context)
        {

            _context = context;
        }

        public Show GetShow(int id)
        {
            return _context.Shows.Where(e => e.ShowId == id).FirstOrDefault();
        }

        public ICollection<Show> GetShows()
        {
            return _context.Shows.ToList();
        }

        public bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.ShowId == id);
        }
    }
}
