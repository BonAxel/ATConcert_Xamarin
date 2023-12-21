using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }
        public bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.GenreId == id);
        }

        public Genre GetGenre(int id)
        {
            return _context.Genres.Where(e => e.GenreId == id).FirstOrDefault();
        }

        public ICollection<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}
