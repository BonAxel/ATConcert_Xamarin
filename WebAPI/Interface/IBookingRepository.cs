using WebAPI.Dto;
using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IBookingRepository
    {
        ICollection<Booking> GetBookings();
        Booking GetBooking(string customerName);
        bool BookingExists(string customerName);
        bool DeleteBooking(int id);
        bool CreateBooking(Booking booking);

        bool Save();
    }
}
