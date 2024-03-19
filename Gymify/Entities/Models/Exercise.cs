using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            Equipment = new HashSet<Equipment>();
            Sessions = new HashSet<Session>();
        }

        public int ExerciseId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int Points { get; set; }
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
