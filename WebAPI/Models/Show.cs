using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        public string Venue { get; set; }
        public DateTime DateTime { get; set; }

        [JsonIgnore]
        public Concert Concert { get; set; }
        
    }
}
