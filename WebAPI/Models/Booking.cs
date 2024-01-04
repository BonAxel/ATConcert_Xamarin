using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public int ShowId { get; set; }
        public Show Show { get; set; }

    }
}
