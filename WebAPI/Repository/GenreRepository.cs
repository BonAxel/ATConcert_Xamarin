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
            throw new NotImplementedException();
        }

        public Genre GetGenre(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Genre> GetGenres()
        {
            throw new NotImplementedException();
        }
    }
}
