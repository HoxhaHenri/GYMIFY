using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Course
    {
        public Course()
        {
            Sessions = new HashSet<Session>();
            Users = new HashSet<Member>();
        }

        public int CourseId { get; set; }
        public Guid GuidIdentifier { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Duration { get; set; }
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;
        public int GymId { get; set; }
        public int CoachId { get; set; }

        public virtual Coach Coach { get; set; } = null!;
        public virtual Gym Gym { get; set; } = null!;
        public virtual ICollection<Session> Sessions { get; set; }

        public virtual ICollection<Member> Users { get; set; }
    }
}
