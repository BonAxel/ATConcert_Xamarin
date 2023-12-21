using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class BookingRepository :IBookingRepository
    {
        private readonly DataContext _context;

        public BookingRepository(DataContext context) 
        {
            _context = context;
        }

        public bool BookingExists(int id)
        {
            return _context.Bookings.Any(p => p.BookingId == id);
        }

        public Booking GetBooking(int id)
        {
            return _context.Bookings.Where(p => p.BookingId == id).FirstOrDefault();
        }

        public ICollection<Booking> GetBookings()
        {
            return _context.Bookings.OrderBy(p => p.BookingId).ToList();
        }

        public bool CreateBooking(int showId, Booking booking)
        {
            var show = _context.Shows.Where(a => a.ShowId == showId).FirstOrDefault();
            booking.Show = show;
            _context.Add(booking);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
