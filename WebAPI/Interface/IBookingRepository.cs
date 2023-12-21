using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IBookingRepository
    {
        ICollection<Booking> GetBookings();
        Booking GetBooking(int id);
        bool BookingExists(int id);

        bool CreateBooking(int showId, Booking booking);

        bool Save();
    }
}
