using WebAPI.Models;

namespace WebAPI.Interface
{
    public interface IBookingController
    {

        ICollection<Booking> GetBookings();
        Booking GetBooking(int id);
        bool BookingExists(int id);

        //POST


    }
}
