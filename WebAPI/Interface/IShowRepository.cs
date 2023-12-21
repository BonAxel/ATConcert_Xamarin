using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IShowRepository
    {
        ICollection<Show> GetShows();
        Show GetShow(int id);
        bool ShowExists(int id);
    }
}
