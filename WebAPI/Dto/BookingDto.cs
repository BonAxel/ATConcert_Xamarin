using WebAPI.Models;

namespace WebAPI.Dto
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public Show Show { get; set; }

    }
}
