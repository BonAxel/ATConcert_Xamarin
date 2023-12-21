using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly DataContext _context;


        public ConcertRepository(DataContext context)
        {
            _context = context;
        }


        public bool ConcertExists(int id)
        {
            throw new NotImplementedException();
        }

        public Concert GetConcert(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Concert> GetConcerts()
        {
            throw new NotImplementedException();
        }
    }
}
