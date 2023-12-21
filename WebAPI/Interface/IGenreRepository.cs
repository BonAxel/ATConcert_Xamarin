using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();
        Genre GetGenre(int id);
        bool GenreExists(int id);
    }
}
