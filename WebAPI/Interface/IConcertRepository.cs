using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IConcertRepository
    {
        ICollection<Concert> GetConcerts();
        Concert GetConcert(int id);
        bool ConcertExists(int id);


    }
}
