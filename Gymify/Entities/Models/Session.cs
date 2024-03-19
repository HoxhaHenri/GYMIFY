using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Session
    {
        public Session()
        {
            Exercises = new HashSet<Exercise>();
        }

        public int SessionId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public DateTime Time { get; set; }
        public int Duration { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
