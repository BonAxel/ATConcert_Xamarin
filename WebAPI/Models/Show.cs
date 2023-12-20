namespace WebAPI.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        public int ConcertId { get; set; }
        public string Venue { get; set; }
        public DateTime DateTime { get; set; }

        public Concert Concert { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public Show(string venue, DateTime datetime, Concert concert, List<Booking> booking)
        {
            Venue = venue;
            DateTime = datetime;
            Concert = concert;
            Bookings = booking;
        }
    }
}
