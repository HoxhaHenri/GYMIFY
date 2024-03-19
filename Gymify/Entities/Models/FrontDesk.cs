using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class FrontDesk
    {
        public FrontDesk()
        {
            Notifications = new HashSet<Notification>();
        }

        public int UserId { get; set; }
        public string Role { get; set; } = null!;
        public int GymId { get; set; }

        public virtual Gym Gym { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
