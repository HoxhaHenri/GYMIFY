using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Content { get; set; } = null!;
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public virtual User Receiver { get; set; } = null!;
        public virtual User Sender { get; set; } = null!;
    }
}
