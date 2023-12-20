using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class ShowRepository : IShowRepository
    {
        public Show GetShow(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Show> GetShows()
        {
            throw new NotImplementedException();
        }

        public bool ShowExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
