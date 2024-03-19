using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Type { get; set; } = null!;
        public DateTime TimeCreated { get; set; }
        public string NotificationMessage { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int FrontDeskId { get; set; }

        public virtual FrontDesk FrontDesk { get; set; } = null!;
    }
}
