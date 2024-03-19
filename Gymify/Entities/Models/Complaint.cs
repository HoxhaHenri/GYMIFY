using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Complaint
    {
        public int ComplaintId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int GymId { get; set; }
        public int UserId { get; set; }

        public virtual Gym Gym { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
