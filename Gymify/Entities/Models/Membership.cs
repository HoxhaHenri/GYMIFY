using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Membership
    {
        public int MembershipId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string Type { get; set; } = null!;
        public int GymId { get; set; }

        public virtual Gym Gym { get; set; } = null!;
    }
}
