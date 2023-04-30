using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolEvents.Models
{
    [Table("Event")]
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Photo { get; set; }
        public DateTime Date { get; set; }
        public virtual HashSet<EventUser> EventUsers { get; set; }
        public Event()
        {
            EventUsers = new HashSet<EventUser>();
        }
    }
}