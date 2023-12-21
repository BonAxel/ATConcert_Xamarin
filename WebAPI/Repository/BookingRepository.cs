using WebAPI.Data;

namespace WebAPI.Repository
{
    public class BookingRepository
    {
        private readonly DataContext _context;

        public BookingRepository(DataContext context)
        {
            _context = context;
        }
    }
}
