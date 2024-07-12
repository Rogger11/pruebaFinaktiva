using System.ComponentModel.DataAnnotations;

namespace Finaktiva.Models
{
    public class EventLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime EventDate { get; set; } = DateTime.Now;
        [Required]
        public string Description { get; set; }
        [Required]
        public string EventType { get; set; } // "API" or "Manual"
    }
}
