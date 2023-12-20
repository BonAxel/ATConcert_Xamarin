namespace WebAPI.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int ShowId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public Show Show { get; set; }

        public Booking(string Customername, string Customeremail, Show show)
        {
            CustomerName = Customername;
            CustomerEmail = Customeremail;
            Show = show;
        }
    }
}
