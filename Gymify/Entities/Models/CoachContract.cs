using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CoachContract
    {
        public int CoachId { get; set; }
        public int GymId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        public virtual Coach Coach { get; set; } = null!;
        public virtual Gym Gym { get; set; } = null!;
    }
}
