using WebAPI.Data;
using WebAPI.Dto;
using WebAPI.Interface;
using WebAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository
{
    public class BookingRepository :IBookingRepository
    {
        private readonly DataContext _context;

        public BookingRepository(DataContext context) 
        {
            _context = context;
        }

        public bool BookingExists(string customerName)
        {
            return _context.Bookings.Any(p => p.CustomerName == customerName);
        }

        public Booking GetBooking(string customerName)
        {
            return _context.Bookings.Where(p => p.CustomerName == customerName).Include(a => a.Show).FirstOrDefault();
        }

        public ICollection<Booking> GetBookings()
        {
            return _context.Bookings.OrderBy(p => p.BookingId).ToList();
        }

        public bool CreateBooking(Booking booking)
        {
            booking.ShowId = booking.Show.ShowId;
            booking.Show = null;
            _context.Add(booking);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeleteBooking(int id)
        {
            var result = _context.Bookings.FirstOrDefault(a => a.BookingId == id);
            if (result == null) return false;
            _context.Remove(result);
            return Save();
        }
    }
}
