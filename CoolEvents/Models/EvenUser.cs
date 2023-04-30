using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEvents.Models
{
    [Table("EventUser")]
    public class EventUser
    {
        public string UserId { get; set; }
        public string EventId { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}