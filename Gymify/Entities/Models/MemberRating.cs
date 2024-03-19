using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class MemberRating
    {
        public int UserId { get; set; }
        public int GymId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public decimal Rating { get; set; }

        public virtual Gym Gym { get; set; } = null!;
        public virtual Member User { get; set; } = null!;
    }
}
