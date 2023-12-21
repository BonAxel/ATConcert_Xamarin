﻿namespace WebAPI.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        public string Venue { get; set; }
        public DateTime DateTime { get; set; }
        public Concert Concert { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        
    }
}
